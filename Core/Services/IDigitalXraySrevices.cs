using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDigitalXraySrevices
    {
        public Task<IEnumerable<Digital_x_rays>> GetAllDigitalXrays(string XrayName);
        public Task<Booking> ScheduleTestAppointment(int DigitalXrayId, int patientId, int? PreciptionId);

        public Task<IEnumerable<Booking>> GetBookingsByPatientId(int patientId);
        public Task<Digital_x_rays> AddDigitalXray(Digital_x_rays digitalXray);
        public Task<Digital_x_rays> UpdateDigitalXray(Digital_x_rays digitalXray);
        public Task<Digital_x_rays> DeleteDigitalXray(Digital_x_rays digitalXray);
    }
}
