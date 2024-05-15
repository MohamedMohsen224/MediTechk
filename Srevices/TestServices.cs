using Core;
using Core.Models;
using Core.Models.Enums;
using Core.Services;
using Core.Specfication;
using Core.Specfication.Params;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reposatry;
using Reposatry.DAta;
using Srevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Srevices
{
    public class TestServices : ITestServices
    {
        private readonly IUnitOfwork unitOfwork;
        private readonly HospitalContext context;

        public TestServices(IUnitOfwork unitOfwork ,HospitalContext context)
        {
            this.unitOfwork = unitOfwork;
            this.context = context;
        }
        // add test
        public Task<Tests> AddTest(Tests tests)
        {
            var test = unitOfwork.Repository<Tests>().AddAsync(tests);
            return test;
            
        }
        // delete test
        public Task<Tests> DeleteTest(Tests tests)
        {
            var test = unitOfwork.Repository<Tests>().DeleteAsync(tests);
            return test;
            
        }
         // Get all tests
        public async Task<IEnumerable<Tests>> GetAllTests(string searchTerm)
        {
            IEnumerable<Tests> tests;

            if (string.IsNullOrEmpty(searchTerm))
            {
                var spec = new TestSpec(); 
                tests = await unitOfwork.Repository<Tests>().GetAllSpecAsync(spec);
            }
            else
            {
                tests = await context.Set<Tests>().Where(t=>t.TestName.ToLower().Contains(searchTerm.ToLower())).ToListAsync();
            }

            return tests.Select(t => new Tests 
            {
                Id = t.Id,
                TestName = t.TestName,
                TestPrice = t.TestPrice,
            });
        }
        // update test
        public Task<Tests> UpdateTest(Tests tests)
        {
            var test = unitOfwork.Repository<Tests>().UpdateAsync(tests);
            return test;
           
        }
        //BookingTest
        public async Task<Booking> ScheduleTestAppointment(int testId, int patientId,int? PreciptionId)
        {

            // Find the test record
            var test = await context.Set<Tests>().FindAsync(testId);
            if (test == null)
            {
                throw new Exception("Test not found.");
            }

            // Calculate appointment date: tomorrow relative to booking time
            var appointmentDate = DateTime.Now.AddDays(1);

            // Check for existing bookings within 48 hours for this patient
            var existingBooking = await context.Set<Booking>()
                 .Where(b => b.PatientId == patientId
                 && b.AppointmentDateTime >= DateTime.Now
                 && b.AppointmentDateTime < appointmentDate.AddHours(48)
                 && b.TestId == testId) 
                 .FirstOrDefaultAsync();

            if (existingBooking != null)
            {
                throw new Exception("Patient already has a booking within the next 48 hours.");
            }

            // Create the booking object
            var booking = new Booking
            {
                TestId = testId,
                PatientId = patientId,
                PrescriptionId = PreciptionId,
                AppointmentDateTime = appointmentDate
            };

            context.Set<Booking>().Add(booking);
            await context.SaveChangesAsync();

            return booking;
        }
        //GetBookingForpatient
        public async Task<IEnumerable<Booking>> GetBookingsByPatientId(int patientId)
        {
            return await context.Set<Booking>()
                .Where(b => b.PatientId == patientId)
                .Include(b => b.Patient)
                .Include(b => b.Test)
                .ToListAsync();
        }
    }
}
