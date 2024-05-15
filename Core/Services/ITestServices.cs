using Core.Models;
using Core.Models.Enums;
using Core.Specfication;
using Core.Specfication.Params;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITestServices
    {

        public Task<IEnumerable<Tests>> GetAllTests(string TestName);
        public Task<IEnumerable<Booking>> GetBookingsByPatientId(int patientId);
        public Task<Tests> AddTest(Tests tests );
        public Task<Tests> UpdateTest(Tests tests);
        public Task<Tests> DeleteTest(Tests tests);

        public Task<Booking> ScheduleTestAppointment(int testId, int patientId, int? PreciptionId);
    }
}
