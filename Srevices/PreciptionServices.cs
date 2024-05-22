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

            prescriptionDto.NextVisit = DateTime.Now.AddDays(15);

            // 1. Create a new Prescription object  
            var prescription = new Prescription
            {
                PrescriptionDate = DateTime.Now,
                NextVisit = prescriptionDto.NextVisit,
                DoctorId = prescriptionDto.DoctorId,
                PatientId = prescriptionDto.PatientId,
                IllnessDescription = prescriptionDto.IllnessDescription, // Assuming first diagnosis as description (optional)
            };

            // 2. Medications
            if (prescriptionDto.Medications != null && prescriptionDto.Medications.Any())
            {
                foreach (var medicationDto in prescriptionDto.Medications)
                {
                    var medication = await context.Medications.FirstOrDefaultAsync(m => m.Medication_Name == medicationDto.Medication.Medication_Name); // Find by name

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

            // 3. Tests
            if (prescriptionDto.Tests != null && prescriptionDto.Tests.Any())
            {
                foreach (var testDto in prescriptionDto.Tests)
                {
                    var test = await context.Tests.FirstOrDefaultAsync(t => t.TestName == testDto.Test.TestName); // Find by name

                    if (test != null)
                    {
                        prescription.Tests.Add(new PresciptionTests
                        {
                            TestId = test.Id,
                            Test = test,
                        });
                    }
                }
            }

            // 4. Digital X-Rays
            if (prescriptionDto.X_Rays != null && prescriptionDto.X_Rays.Any())
            {
                foreach (var xRayDto in prescriptionDto.X_Rays)
                {
                    var digitalXRay = await context.Digital_X_Rays.FirstOrDefaultAsync(x => x.Name == xRayDto.DigitalXRay.Name); // Find by name

                    if (digitalXRay != null)
                    {
                        prescription.X_Rays.Add(new PreciptionDigitalxrays
                        {
                            DigitalXRayId=digitalXRay.Id,
                            DigitalXRay = digitalXRay,
                        });
                    }
                }
            }

            // 5. Save changes to the database
            await context.Prescriptions.AddAsync(prescription);
            await context.SaveChangesAsync();

            // 6. Return the created prescription
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
                .ThenInclude(d=>d.Clinic)
                .ToListAsync();
        }
    }
}
