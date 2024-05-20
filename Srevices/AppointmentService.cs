using Core;
using Core.Models;
using Core.Models.Enums;
using Core.Services;
using Core.Specfication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srevices
{
    public class AppointmentService : IAppointmentServices
    {
        private readonly IUnitOfwork unitOfwork;
        private readonly HospitalContext context;

        public AppointmentService(IUnitOfwork unitOfwork , HospitalContext context )
        {
            this.unitOfwork = unitOfwork;
            this.context = context;
        }
        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            if (!Enum.TryParse<DayOfWeek>(appointment.SelectedDay, true, out DayOfWeek workingDay))
            {
                throw new ArgumentException("Invalid day provided.");
            }

            var doctor = await context.Doctors.FindAsync(appointment.DoctorId);
            if (doctor == null)
            {
                throw new ArgumentException("Doctor not found.");
            }

            if (!doctor.WorkingDays.Contains(workingDay.ToString()))
            {
                throw new ArgumentException("Doctor is not available on the chosen day.");
            }

            // Check for existing appointments within 48 hours for this patient and doctor
            var existingBooking = await context.Appointments
                .Where(a => a.PatientId == appointment.PatientId
                         && a.DoctorId == appointment.DoctorId
                         && a.AppointmentDateTime >= DateTime.UtcNow
                         && a.AppointmentDateTime < DateTime.UtcNow.AddDays(2)) // Check within 48 hours
                .FirstOrDefaultAsync();

            if (existingBooking != null)
            {
                throw new ArgumentException("Patient already has an appointment with this doctor within the next 48 hours.");
            }

            // Check for existing appointments with the same doctor within the last 48 hours
            var existingAppointmentsWithDoctor = await context.Appointments
                .Where(a => a.PatientId == appointment.PatientId
                         && a.DoctorId == appointment.DoctorId
                         && a.AppointmentDateTime >= DateTime.UtcNow.AddDays(-2) // Check back 48 hours
                         && a.AppointmentDateTime < DateTime.UtcNow)
                .ToListAsync();

            if (existingAppointmentsWithDoctor.Any())
            {
                throw new ArgumentException("Patient already has an appointment with this doctor within the last 48 hours.");
            }

            // Check for existing appointments with the same doctor regardless of time
            var existingAppointments = await context.Appointments
                .Where(a => a.PatientId == appointment.PatientId
                         && a.DoctorId == appointment.DoctorId)
                .ToListAsync();

            if (existingAppointments.Any())
            {
                throw new ArgumentException("Patient already has an appointment with this doctor.");
            }

            // Check if the doctor is already fully booked for the chosen day
            int appointmentsOnChosenDay = await context.Appointments
                .CountAsync(a => a.DoctorId == appointment.DoctorId
                              && a.AppointmentDateTime.Date == appointment.AppointmentDateTime.Date);

            if (appointmentsOnChosenDay >= 20)
            {
                throw new InvalidOperationException("Doctor is already fully booked for the chosen date. Please choose another date or doctor.");
            }

            // Existing logic for appointment count and date (unchanged)
            int nextAppointmentNumber = 1;
            var existingAppointment= await context.Appointments.Where(a => a.DoctorId == doctor.Id).ToListAsync();
            if (existingAppointments.Any())
            {
                nextAppointmentNumber = existingAppointments.Max(a => a.AppointmentCount) + 1;
            }
            var appointmentTime = await CalculateAppointmentTime(appointment.DoctorId, appointment.SelectedDay);

            // Set the calculated appointment time
            appointment.AppointmentTime = appointmentTime;

            appointment.AppointmentCount = nextAppointmentNumber;
            appointment.AppointmentDateTime = DateTime.UtcNow.Date.AddDays((int)workingDay);

            context.Appointments.Add(appointment);
            await context.SaveChangesAsync();

            return appointment;
        }


       
        public async Task<List<Appointment>> GetAppointmentByDoctorId(int DoctorId , string dayOfWeek)
        {
            if (!Enum.TryParse<DayOfWeek>(dayOfWeek, true, out DayOfWeek day))
            {
                throw new ArgumentException("Invalid day provided.");
            }

            var doctor = await context.Doctors
                .Include(d => d.Appointments).ThenInclude(d=>d.Patient) // Include Appointments navigation property
                .FirstOrDefaultAsync(d => d.Id == DoctorId);

            if (doctor == null)
            {
                throw new ArgumentException("Doctor not found.");
            }

            if (!doctor.WorkingDays.Contains(dayOfWeek))
            {
                throw new ArgumentException("Doctor is not available on that chosen day.");
            }

            var appointments = doctor.Appointments.Where(a => a.SelectedDay == dayOfWeek).ToList();
            return appointments;

        }
        //GetAppointmetnForPatient
        public async Task<IReadOnlyList<Appointment>> GetAppointmentByPatientId(int PatientId)
        {
            var spec = new AppointmentPATIENTsPEC(PatientId);
            return await unitOfwork.Repository<Appointment>().GetAllSpecAsync(spec);
        }
        //CancelAppointment
        public async Task CancelAppointment(int appointmentId)
        {
            try
            {
                var appointment = await context.Appointments.FindAsync(appointmentId);

                if (appointment == null)
                {
                    throw new Exception("Appointment not found.");
                }



                context.Appointments.Remove(appointment);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to cancel appointment. Please try again later.");
            }
              
           

        }

        private async Task<TimeSpan> CalculateAppointmentTime(int? doctorId, string selectedDay)
        {

            
             var doctor = await context.Doctors.FindAsync(doctorId);
            if (doctor == null)
            {
                throw new ArgumentException("Doctor not found.");
            }

            // Parse the selected day
            if (!Enum.TryParse<DayOfWeek>(selectedDay, true, out DayOfWeek workingDay))
            {
                throw new ArgumentException("Invalid day provided.");
            }

            // Check if the doctor works on the selected day
            if (!doctor.WorkingDays.Contains(workingDay.ToString()))
            {
                throw new ArgumentException("Doctor is not available on the chosen day.");
            }

           

            // Calculate the appointment duration
            var appointmentDuration = TimeSpan.FromMinutes(30);

            // Initialize the next appointment time as the doctor's start time
            TimeSpan nextAppointmentTime = doctor.StartTime;

            // Check if the current time exceeds the doctor's end time
        

            // Get existing appointments for the chosen day
            var existingAppointments = await context.Appointments
                .Where(a => a.DoctorId == doctorId && a.SelectedDay == selectedDay)
                .OrderBy(a => a.AppointmentTime)
                .ToListAsync();

            // Find the first available time slot with a 30-minute gap
            foreach (var existingAppointment in existingAppointments)
            {
                // Check if there's a gap of at least 30 minutes between appointments
                if (existingAppointment.AppointmentTime - nextAppointmentTime >= appointmentDuration)
                {
                    return nextAppointmentTime;
                }

                // Move to the next available time slot by adding the appointment duration
                nextAppointmentTime = existingAppointment.AppointmentTime + appointmentDuration;
            }

            // Check if the next appointment time exceeds the doctor's end time
            if (nextAppointmentTime == doctor.EndTime)
            {
                throw new InvalidOperationException("No more available time slots for the chosen doctor and date.");
            }

            return nextAppointmentTime;
        }
        }
    }





