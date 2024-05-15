using Core.Models;
using Core.Specfication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPreceptionServices
    {
        public Task<Prescription> CreatePrescription(Prescription prescriptionDto);


        public Task<bool> DeletePrescription(int prescriptionId);

        public Task<IEnumerable<Prescription>> GetPrescriptionsByDoctorAndPatient(int doctorId, int patientId);


    }
}
