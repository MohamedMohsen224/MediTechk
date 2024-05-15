using Core;
using Core.Models;
using Core.Services;
using Core.Specfication;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srevices
{
    public class DigitalXrayServices : IDigitalXraySrevices
    {
        private readonly IUnitOfwork unitOfwork;
        private readonly HospitalContext context;

        public DigitalXrayServices(IUnitOfwork unitOfwork ,HospitalContext context)
        {
            this.unitOfwork = unitOfwork;
            this.context = context;
        }

        //add new digital xray
        public async Task<Digital_x_rays> AddDigitalXray(Digital_x_rays digitalXray)
        {
            var digital = await unitOfwork.Repository<Digital_x_rays>().AddAsync(digitalXray);
            return digital;

        }
        //delete digital xray
        public async Task<Digital_x_rays> DeleteDigitalXray(Digital_x_rays digitalXray)
        {
            var digital = await unitOfwork.Repository<Digital_x_rays>().DeleteAsync(digitalXray);
            return digital;
        }
        //update digital xray
        public async Task<Digital_x_rays> UpdateDigitalXray(Digital_x_rays digitalXray)
        {
            var Digital = await unitOfwork.Repository<Digital_x_rays>().UpdateAsync(digitalXray);
            return digitalXray;
        }
        //get all digital xray with search
        public async Task<IEnumerable<Digital_x_rays>> GetAllDigitalXrays(string searchTerm )
        {
            IEnumerable<Digital_x_rays> digital_X_Rays;

            if (string.IsNullOrEmpty(searchTerm))
            {
                var spec = new DigitalXraySpec();
                digital_X_Rays = await unitOfwork.Repository<Digital_x_rays>().GetAllSpecAsync(spec);
            }
            else
            {
                digital_X_Rays =  await context.Set<Digital_x_rays>()
                .Where(m => m.Name.ToLower().Contains(searchTerm.ToLower()))
                .ToListAsync();
            }

            return digital_X_Rays.Select(t => new Digital_x_rays 
            {
                Id = t.Id,
                Name = t.Name,
                Price = t.Price,
                
            });
        }
      
        public async Task<Booking> ScheduleTestAppointment(int DigitalXrayId, int patientId, int? PreciptionId)
        {

            var digitalXray = await context.Set<Digital_x_rays>().FindAsync(DigitalXrayId);
            if (digitalXray == null)
            {
                throw new Exception("Digital X-ray not found.");
            }

            // Find the patient record
            var patient = await context.Set<Patient>().FindAsync(patientId);
            if (patient == null)
            {
                throw new Exception("Patient not found.");
            }

            // Calculate appointment date: tomorrow relative to booking time
            var appointmentDate = DateTime.Now.AddDays(1);

            // Check for existing bookings within 48 hours for this patient and test
            var existingBooking = await context.Set<Booking>()
                .Where(b => b.PatientId == patientId
                           && b.AppointmentDateTime >= DateTime.Now
                           && b.AppointmentDateTime < appointmentDate.AddHours(48)
                           && b.DigitalXRayId == DigitalXrayId) // Filter by specific test (DigitalXRayId)
                .FirstOrDefaultAsync();

            if (existingBooking != null)
            {
                throw new Exception("Patient already has a booking for this X-ray within the next 48 hours.");
            }

            // Create the booking object
            var booking = new Booking
            {
                DigitalXRayId = DigitalXrayId,
                PatientId = patientId,
                PrescriptionId = PreciptionId,
                AppointmentDateTime = appointmentDate
            };

            context.Set<Booking>().Add(booking);
            await context.SaveChangesAsync();

            return booking;
        }


        public async Task<IEnumerable<Booking>> GetBookingsByPatientId(int patientId)
        {
            return await context.Set<Booking>()
                .Where(b => b.PatientId == patientId)
                .Include(b => b.Patient)
                .Include(b => b.DigitalXRay)
                .ToListAsync();
        }


    }
}
