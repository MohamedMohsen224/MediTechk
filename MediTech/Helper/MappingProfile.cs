using AutoMapper;
using Core.Models;
using Core.Models.Enums;
using Core.Models.Identity;
using MediTech.Dtos;
using Reposatry.DAta;
using System.Collections.Immutable;
using static MediTech.Helper.ProfilePictureUrlResolverForDoctor;
using static MediTech.Helper.ProfilePictureUrlResolverForPatient;


namespace MediTech.Helper
{
    public class MappingProfile : Profile
    {
        private readonly HospitalContext context;

        public MappingProfile( HospitalContext context)
        {
            this.context = context;

            #region Clinic
            CreateMap<Clinic, ClinicDto>()
                .ForMember(d => d.Amout, opt => opt.MapFrom(d => d.AmoutForBook));
            #endregion
            #region Doctor
            CreateMap<Doctor, DoctorDto>()/*.ForMember(d => d.Profile_Picture, opt => opt.MapFrom<ProfilePictureUrlResolverForDoctor>())*/
                  .ForMember(d => d.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(d => d.Clinic, opt => opt.MapFrom(src => src.Clinic.Clinic_Name))
               .ForMember(d => d.Doctor_Name, opt => opt.MapFrom(src => src.DisplayName))
               .ForMember(d => d.Clinic, opt => opt.MapFrom(src => src.Clinic.Clinic_Name))
               .ForMember(d => d.Doctor_Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(d => d.Speachlization, opt => opt.MapFrom(src => src.Speachlization))
               .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
               .ForMember(d => d.Telephone, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(d => d.StartTime, opt => opt.MapFrom(src => src.StartTime))
               .ForMember(d => d.EndTime, opt => opt.MapFrom(src => src.EndTime))
              .ForMember(
              dest => dest.Workingdays,
              opt => opt.MapFrom(src => src.WorkingDays != null ? src.WorkingDays.Select(day => day.ToString()).ToList() : new List<string>())
                );

            #endregion
            #region Patient
            CreateMap<Patient, PatientDto>().ForMember(d => d.UserName, p => p.MapFrom(p => p.UserName))
            .ForMember(d => d.Id, opt => opt.MapFrom(d => d.Id))
            .ForMember(d => d.Profile_Picture, opt => opt.MapFrom(p=>p.Profile_Picture))
            .ForMember(d => d.Gender, opt => opt.MapFrom(d => d.Gender))
            .ForMember(d => d.Telephone, opt => opt.MapFrom(d => d.PhoneNumber))
            .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(d => d.DateOfBirth))
            .ForMember(d => d.Email, opt => opt.MapFrom(d => d.Email))
            .ForMember(d => d.NationalId, opt => opt.MapFrom(d => d.NationalID));
            #endregion
            #region Prescription
            CreateMap<Prescription, PrescriptionDto>()
           .ForMember(d => d.PrescriptionId, opt => opt.MapFrom(d => d.Id))
           .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.DisplayName))
           .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.UserName))
           .ForMember(dest=>dest.IllnessDescription,opt=>opt.MapFrom(src=>src.IllnessDescription))
           .ForMember(dest => dest.Medications, opt => opt.MapFrom(src => src.Medications.Select(m => new PrescriptionMedicationDto
           {
               // Map medication details
               Id=m.MedicationId,
               Name = m.Medication.Medication_Name,
               Dose = m.Dose

           })))
           .ForMember(dest => dest.Tests, opt => opt.MapFrom(src => src.Tests.Select(t => new PrescriptionTestDto
           {
               Id = t.TestId,
               Name = t.Test.TestName, // Assuming Test has a TestName property
               Price = t.Test.TestPrice, // Assuming Test has a TestPrice property
           })))
           .ForMember(dest => dest.DigitalXRays, opt => opt.MapFrom(src => src.X_Rays.Select(x => new PrescriptionDigitalXRayDto
           {
               Id=x.DigitalXRayId,
               Name = x.DigitalXRay.Name, // Assuming DigitalXRay has a Name property
               Price = x.DigitalXRay.Price, // Assuming DigitalXRay has a Price property
           })));

            #endregion
            #region CreatePrescription
            CreateMap<NewPresiptionDto, Prescription>()
            .ForMember(dest => dest.Medications, opt => opt.MapFrom(src => src.MedicationNames.Select(m => new PresiptionMedication
            {
                Medication = context.Medications.FirstOrDefault(med =>
               med.Medication_Name == m.Name 
               
                   ),
                Dose = m.Dose
            })))
            .ForMember(dest => dest.Tests, opt => opt.MapFrom(src => src.TestNames.Select(m => new PresciptionTests
            {
                Test = context.Tests.FirstOrDefault(med =>
               med.TestName == m.Name 
                   ),
                
               
            })))
             .ForMember(dest => dest.X_Rays, opt => opt.MapFrom(src => src.DigitalXRayNames.Select(m => new PreciptionDigitalxrays
             {
                 DigitalXRay = context.Digital_X_Rays.FirstOrDefault(med =>
                med.Name == m.Name 
                   ),

             })))
          .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
          .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
          .ForMember(dest => dest.IllnessDescription, opt => opt.MapFrom(src => src.IllnessDescription));
           #endregion
            #region Test
            CreateMap<Tests, TestDto>()
                .ForMember(d => d.TestId, opt => opt.MapFrom(d => d.Id))
                .ForMember(d => d.TestName, opt => opt.MapFrom(d => d.TestName))
                .ForMember(d => d.TestPrice, opt => opt.MapFrom(d => d.TestPrice));
            #endregion
            #region Appointment
            CreateMap<Appointment, AppointmentDto>()
           .ForMember(dest => dest.AppointmentNumber, opt => opt.MapFrom(src => src.AppointmentCount))
           .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.AppointmentDateTime.Date))
           .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor.DisplayName))
           .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient.UserName))
           .ForMember(dest => dest.DoctorStartTime, opt => opt.MapFrom(src => src.Doctor.StartTime))
           .ForMember(dest => dest.DoctorEndTime, opt => opt.MapFrom(src => src.Doctor.EndTime))
           .ForMember(dest=>dest.day,opt=>opt.MapFrom(src=>src.SelectedDay.ToString().ToList()));

            #endregion    
            #region Medication
    CreateMap<Medication, MedicationDto>()
                .ForMember(d => d.Medication_Name, opt => opt.MapFrom(d => d.Medication_Name))
                .ForMember(d => d.Medication_Type, opt => opt.MapFrom(d => d.Medication_Type))
                .ForMember(d => d.medication_Price, opt => opt.MapFrom(d => d.medication_Price))
                .ForMember(d => d.Expiration_Date, opt => opt.MapFrom(d => d.Expiration_Date))
                .ForMember(d => d.IsAvailable, opt => opt.MapFrom(d => d.IsAvailable));
            #endregion
            #region DigitalXrays
            CreateMap<Digital_x_rays, DigitalXRayDto>()
                .ForMember(d => d.XrayId, opt => opt.MapFrom(d => d.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(d => d.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(d => d.Price));
            #endregion
            #region BookingTest
            CreateMap<Booking, BookingTestDto>()
                .ForMember(d => d.BookingID, opt => opt.MapFrom(d => d.BookingID))
                .ForMember(d => d.PatientId, opt => opt.MapFrom(d => d.PatientId))
                .ForMember(d => d.PrescriptionId, opt => opt.MapFrom(d => d.PrescriptionId));

            #endregion
            #region BookingDigitalXray
            CreateMap<Booking, BookingDigitalXraysDto>()
                .ForMember(d=>d.DigitalXRayName,opt=>opt.MapFrom(d=>d.DigitalXRay.Name))
                 .ForMember(d=>d.PatientName,opt=>opt.MapFrom(d=>d.Patient.UserName))
                .ForMember(d => d.BookingID, opt => opt.MapFrom(d => d.BookingID))
                .ForMember(d => d.DigitalXRayId, opt => opt.MapFrom(d => d.DigitalXRayId))
                .ForMember(d => d.PatientId, opt => opt.MapFrom(d => d.PatientId))
                .ForMember(d=>d.PrescriptionId,opt=>opt.MapFrom(d=>d.PrescriptionId));
            #endregion
            #region CreateAppointment
            CreateMap<Create_appointmentDto, Appointment>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId)) // Explicit mapping for PatientId
                .ForMember(dest => dest.SelectedDay, opt => opt.MapFrom(src => src.SelectedDay))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId));
            #endregion
            #region Appointmentpatient
            CreateMap<Appointment, AppointmentForpatient>()
          .ForMember(dt => dt.id, opt => opt.MapFrom(d => d.Id)) // Handle potential null Doctor
          .ForMember(dt => dt.Doctor, opt => opt.MapFrom(d => d.Doctor.DisplayName)) // Handle potential null Doctor
          .ForMember(dt => dt.Date, opt => opt.MapFrom(d => d.AppointmentDateTime.Date)) // Extract date from DateTime
          .ForMember(dt => dt.DoctorStartTime, opt => opt.MapFrom(d => d.Doctor.StartTime))
          .ForMember(dt => dt.DoctorEndTime, opt => opt.MapFrom(d => d.Doctor.EndTime))
          .ForMember(dt => dt.AppointmentNumber, opt => opt.MapFrom(d => d.AppointmentCount))
          .ForMember(dt => dt.day, opt => opt.MapFrom(d => d.SelectedDay.ToString()));
            #endregion
            #region AppointmentDoctor
            CreateMap<Appointment, AppointmentFordoctor>()
           .ForMember(dt=>dt.PatientId,opt=>opt.MapFrom(d=>d.PatientId))
           .ForMember(dt => dt.Patient, opt => opt.MapFrom(d => d.Patient.UserName)) // Handle potential null Doctor
           .ForMember(dt => dt.Date, opt => opt.MapFrom(d => d.AppointmentDateTime)) // Extract date from DateTime          
           .ForMember(dt => dt.AppointmentNumber, opt => opt.MapFrom(d => d.AppointmentCount))
           .ForMember(dt => dt.day, opt => opt.MapFrom(d => d.SelectedDay.ToString()));
            #endregion
            CreateMap<Doctor, DoctorProfile>().ForMember(
              dest => dest.Workingdays,
              opt => opt.MapFrom(src => src.WorkingDays != null ? src.WorkingDays.Select(day => day.ToString()).ToList() : new List<string>())
                );

          
        }

    }
}
