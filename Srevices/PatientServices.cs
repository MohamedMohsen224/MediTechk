using Core;
using Core.Models;
using Core.Services;
using Core.Specfication;
using Core.Specfication.Params;
using Reposatry;
using Reposatry.DAta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srevices
{
    public class PatientServices : IPatientService
    {
        private readonly IUnitOfwork unitOfwork;
        private readonly HospitalContext context;

        public PatientServices(IUnitOfwork unitOfwork ,HospitalContext context )
        {
            this.unitOfwork = unitOfwork;
            this.context = context;
        }
        //GetAllPatients
        public async Task<IReadOnlyList<Patient>> GetallPatientSpecAsync(PatientParams patientParams)
        {
            var PatientSpec = new PatientSpeac(patientParams);

            var Patients = await unitOfwork.Repository<Patient>().GetAllSpecAsync(PatientSpec);

            return Patients;
        }


        public Task<Patient> GetPatientByIdAsync(int id)
        {
            var Spec = new PatientSpeac(id);
            var Patient = unitOfwork.Repository<Patient>().GetByIdSpecAsync(Spec);
            return Patient;
        }

        public async Task<Patient> UpdatePatientDataAsync(int patientId, Patient updatedPatientData)
        {
            // Check if the updated patient data is null
            if (updatedPatientData == null)
            {
                throw new ArgumentNullException(nameof(updatedPatientData), "Updated patient data cannot be null.");
            }

            // Check if the patient ID is valid
            if (patientId <= 0)
            {
                throw new ArgumentException("Invalid patient ID. ID must be a positive integer.", nameof(patientId));
            }

            // Find the existing patient by ID
            var existingPatient =  context.Patients.FirstOrDefault(p => p.Id == patientId);

            // Check if the existing patient is null
            if (existingPatient == null)
            {
                throw new InvalidOperationException($"Patient with ID {patientId} not found.");
            }

            // Update patient properties based on the updatedPatientData object
            existingPatient.Profile_Picture = updatedPatientData.Profile_Picture ?? existingPatient.Profile_Picture;
            existingPatient.UserName = updatedPatientData.UserName ?? existingPatient.UserName;
            existingPatient.Gender = updatedPatientData.Gender ?? existingPatient.Gender;
            existingPatient.DateOfBirth = updatedPatientData.DateOfBirth ?? existingPatient.DateOfBirth;
            existingPatient.Email = updatedPatientData.Email ?? existingPatient.Email;
            existingPatient.Address = updatedPatientData.Address ?? existingPatient.Address;
            existingPatient.PhoneNumber = updatedPatientData.PhoneNumber ?? existingPatient.PhoneNumber;
            existingPatient.NationalID = updatedPatientData.NationalID ;

            // Save changes to the database
            context.Patients.Update(existingPatient);
            await context.SaveChangesAsync();

            return existingPatient;
        }



    }
}
