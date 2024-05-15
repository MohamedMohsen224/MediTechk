using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAppointmentServices
    {
        //public Task<Appointment> CreateAppointment(Appointment appointmentDto);
        public  Task<Appointment> CreateAppointment(Appointment appointment);


        public Task<List<Appointment>> GetAppointmentByDoctorId(int DoctorId , string dayOfWeek);

        public Task<IReadOnlyList<Appointment>> GetAppointmentByPatientId(int PatientId);

        public  Task CancelAppointment(int appointmentId);



    }
}
