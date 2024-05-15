using Core.Models;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srevices
{
    public class PreciptionServices : IPreceptionServices
    {
        private readonly HospitalContext context;

        public PreciptionServices(HospitalContext context )
        {
            this.context = context;
        }

        public async Task<Prescription> CreatePrescription(Prescription prescriptionDto)
        {
            if (prescriptionDto.NextVisit == null || prescriptionDto.DoctorId == 0 || prescriptionDto.PatientId == 0)
            {
                throw new ArgumentException("Required fields missing in prescription data.");
            }
            prescriptionDto.NextVisit=DateTime.Now.AddDays(15);
            // 2. Create a new Prescription object
            var prescription = new Prescription
            {
                PrescriptionDate = DateTime.Now,
                NextVisit = prescriptionDto.NextVisit,
                DoctorId = prescriptionDto.DoctorId,
                PatientId = prescriptionDto.PatientId,
                Illness = prescriptionDto.Illness,
                Description= prescriptionDto.Description,
            };
           

            

          
            var medicationIds = prescriptionDto.Medications?.Select(m => m.Medication.Medication_Name).ToList();
            if (prescriptionDto.Medications != null && prescriptionDto.Medications.Any())
            {
                foreach (var medicationDto in prescriptionDto.Medications)
                {
                    // **Potential Issue:** Assuming `Medication` property exists 
                    var medication = await context.Medications
                        .Where(m => m.Medication_Name == medicationDto.Medication.Medication_Name)
                        .FirstOrDefaultAsync();

                    if (medication != null)
                    {
                        prescription.Medications.Add(new PresiptionMedication
                        {
                            Medication = medication,
                            Dose = medicationDto.Dose // Assign doctor-provided dose
                        });
                    }
                }
            }


            if (prescriptionDto.Tests != null && prescriptionDto.Tests.Any())
            {
                var tests = await context.Tests
                                          .Where(t => prescriptionDto.Tests.Select(dto => dto.Test.TestName).Contains(t.TestName))
                                          .ToListAsync();

                foreach (var test in tests)
                {
                    prescription.AddTest(test);
                }
            }

            if (prescriptionDto.X_Rays != null && prescriptionDto.X_Rays.Any())
            {
                var xRayName = prescriptionDto.X_Rays.First().DigitalXRay.Name;

                var digitalXRay = await context.Digital_X_Rays
                                            .Where(x => x.Name == xRayName)
                                            .FirstOrDefaultAsync();

                if (digitalXRay != null)
                {
                    prescription.AddDigitalXRay(digitalXRay);
                }
                
            }


            // 8. Save changes to the database


            await context.Prescriptions.AddAsync(prescription);
            await context.SaveChangesAsync();

            // 8. Return the created prescription
            return prescription;
        }






       // DeletePreciption
        public async Task<bool> DeletePrescription(int prescriptionId)
        {
            // Find the prescription by ID
            var prescription = await context.Prescriptions.FindAsync(prescriptionId);
            if (prescription == null)
            {
                return false; // Prescription not found
            }

            // Permanent Delete (remove from database)
            context.Prescriptions.Remove(prescription);

            // Save changes to the database
            await context.SaveChangesAsync();

            return true; // Deletion successful
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByDoctorAndPatient(int doctorId, int patientId)
        {
            return await context.Prescriptions
                .Where(p => p.DoctorId == doctorId && p.PatientId == patientId)
                .Include(p => p.Medications)
                .ThenInclude(m => m.Medication)
                .Include(p => p.Tests)
                .ThenInclude(t => t.Test)
                .Include(p => p.X_Rays)
                .ThenInclude(x => x.DigitalXRay)
                .Include(d=>d.Patient)
                .Include(d=>d.Doctor)
                .ToListAsync();
        }
    }
}
