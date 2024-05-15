using Core.Models;
using Core.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Reposatry.Data
{
    public static class SeedData
    {
        public async static Task SeedAsync(HospitalContext _dbContext)
        {
            if (_dbContext.Departments.Count() == 0)
            {
                var Department = new List<Department>()
               {
                   new Department{
                       Department_Name= "Operations and endoscopy",
                       Department_Description="The department is concerned with performing operations and endoscopy, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of operations and endoscopy, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a"




                   },
                   new Department
                   {
                          Department_Name= "Nurseries and child care",
                          Department_Description="The department is concerned with the care of children and newborns, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of child care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of"


                   },
                   new Department
                   {
                              Department_Name= "Intensive care",
                              Department_Description="The department is concerned with the care of patients in critical condition, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of"


                     },
                   new Department
                   {
                                Department_Name= "Catheterization and cardiac care",
                                Department_Description="The department is concerned with the care of patients with heart diseases, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of heart care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of"


                   },
                   new Department
                   {
                                        Department_Name= "Emergency",
                                        Department_Description="The department is concerned with the care of patients in critical condition, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of intensive care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of"


                     },
                   new Department
                   {
                        Department_Name= "Department of Obstetrics and Gynecology",
                        Department_Description="The department is concerned with the care of pregnant"


                   },
                   new Department
                   {
                            Department_Name= "blood bank",
                            Department_Description="Blood Bank provides all types of blood, plasma, and platelets around the clock, 7 days a week, including rare types.\r\n\r\nIt also provides a free exchange service for blood and its derivatives in the case of donationThe blood bank is supervised by an elite group of consultant doctors with more than 20 years of experience in the field of blood banks"


                     },
                   new Department
                   {
                        Department_Name= "Accommodation-internal",
                        Department_Description=" Specialized Hospital is distinguished by its high-level luxury accommodation rooms for the comfort of patients, visitors and companions.There are also several levels of accommodation rooms according to the client’s choice"

                   },
                   new Department
                   {
                            Department_Name= "Hemodialysis",
                            Department_Description="The department is distinguished by the presence of Swedish-made Gambro dialysis machines and all Swedish-made medical supplies for dialysis sessions and dialysis filters.\r\n\r\nThe hospital has a laundry room for urgent emergency cases\r\n\r\nThere are plasma separation sessions for immune blood diseases, immune nervous system diseases, and immune rheumatic diseases under the supervision of a group of consultants and specialists."

                   },
                   new Department
                   {
                            Department_Name= "natural therapy",
                            Department_Description="The Physical Therapy Department is distinguished by the latest European equipment and is interested in specializing in all fields of physical therapy with the latest protocols for treating all bone, brain and nerve conditions, post-operative treatment and intensive care at the hands of physical therapists trained in the latest methods of manual and other physical therapy.\r\n"

                   },
                   new Department
                   {
                             Department_Name= "the teeth",
                             Department_Description="Cosmetic fillings for children under local and general anesthesia,Cosmetic and orthodontics,Oral and Maxillofacial Surgery,Dental implants,Dental fillings,Hollywood smile,Fixed and mobile installations,Gum disease treatment,Removal of lime deposits using the latest equipment,With the latest technical means in accordance with international infection control standards"

                     },
                   new Department
                   {
                         Department_Name= "Pharmacy",
                         Department_Description="Hospital Pharmacy is comprehensive and provides pharmaceutical care through two main branchesThe hospital’s internal pharmacy: It serves internal department patients 24 hours a day and provides them with all necessary medications.Outpatient Pharmacy: which also provides 24-hour service.All pharmaceutical preparations are handled by the competent hands of well-trained pharmacists.All pharmaceutical activities are carried out under the supervision of the Pharmacy and Therapeutics Committee.Quality standards are applied in all pharmaceutical practices and methods of dispensing medication, and the pharmacist is also concerned with educating the patient on the most appropriate ways to use the medication."


                   },
                   new Department
                   {
                             Department_Name= "Ophthalmia",
                             Department_Description="The department is concerned with the care of the eyes, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of"

                   },
                   new Department
                   {
                              Department_Name= "Vision correction (LASIK)",
                              Department_Description="The department is concerned with the care of the eyes, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of eye care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in"
                   },
                   new Department
                   {
                                Department_Name= "The laboratory",
                                Department_Description="The laboratory is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of laboratory"

                   },
                   new Department
                   {
                                  Department_Name= "Oncology diagnosis and treatment unit",
                                  Department_Description="The department is concerned with the care of patients with cancer, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized"

                   },
                   new Department
                   {
                                        Department_Name= "x_ray place",
                                        Department_Description="The department is concerned with the care of patients with cancer, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of cancer care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized"

                   },
                   new Department
                   {
                                         Department_Name= "Obesity and thinness",
                                         Department_Description="The department is concerned with the care of patients with obesity and thinness, and it includes a group of specialized doctors and nurses, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it is characterized by the presence of a group of specialized doctors in the field of obesity and thinness care, and it is equipped with the latest medical devices and equipment, and it"

                   },
                   new Department
                   {
                                             Department_Name= " Male diseases",
                                             Department_Description="The department is concerned with the care of patients"

                   },



               };
                await _dbContext.Departments.AddRangeAsync(Department);
                await _dbContext.SaveChangesAsync();


            }
            if (_dbContext.Clinics.Count() == 0)
            {
                var Clinic = new List<Clinic>()
                {
                    new Clinic
                    {
                        Clinic_Name= "Chest and respiratory diseases",
                        Clinic_Location= "F1",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 100
                    },
                    new Clinic
                    {
                        Clinic_Name= "Urology and andrology surgery",
                        Clinic_Location= "F1",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 150
                    },
                    new Clinic
                    {
                        Clinic_Name= "Subconscious",
                        Clinic_Location= "F1",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 200
                    },
                    new Clinic
                    {
                        Clinic_Name= "Gynecology and childbirth",
                        Clinic_Location= "F2",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 250
                    },
                    new Clinic
                    {
                        Clinic_Name= "Dental clinic",
                        Clinic_Location= "F2",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 300
                    },
                    new Clinic
                    {
                        Clinic_Name= "Bones",
                        Clinic_Location= "F3",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 350
                    },
                    new Clinic
                    {
                        Clinic_Name= "Pediatric surgery",
                        Clinic_Location= "F3",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 400
                    },
                    new Clinic
                    {
                        Clinic_Name= "Dermatology and Venereology",
                        Clinic_Location= "F3",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 450
                    },
                    new Clinic
                    {
                        Clinic_Name= "General Surgery",
                        Clinic_Location= "F4",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 500
                    },
                    new Clinic
                    {
                        Clinic_Name= "Nutrition and obesity surgeries",
                        Clinic_Location= "F4",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 550
                    },
                    new Clinic
                    {
                        Clinic_Name= "brain and nerves",
                        Clinic_Location= "F5",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 600
                    },
                    new Clinic
                    {
                        Clinic_Name= "Blood vessels",
                        Clinic_Location= "F5",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 650
                    },
                    new Clinic
                    {
                        Clinic_Name= "Blood diseases",
                        Clinic_Location= "F5",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 700
                    },
                    new Clinic
                    {
                        Clinic_Name= "Heart and echo",
                        Clinic_Location= "F6",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 750
                    },
                    new Clinic
                    {
                        Clinic_Name= "Oncology surgery",
                        Clinic_Location= "F6",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 800
                    },
                    new Clinic
                    {
                        Clinic_Name= "Psychological and neurological",
                        Clinic_Location= "F6",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 850
                    },
                    new Clinic
                    {
                        Clinic_Name= "Knee roughness",
                        Clinic_Location= "F7",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 900
                    },
                    new Clinic
                    {
                        Clinic_Name= "natural therapy",
                        Clinic_Location= "F7",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 950
                    },
                    new Clinic
                    {
                        Clinic_Name= "Endocrine glands and sugar",
                        Clinic_Location= "F7",
                        Clinic_Phone= "555-1234",

                        AmoutForBook= 1000
                    },
                    new Clinic
                    {
                        Clinic_Name= "Ear, nose and throat",
                        Clinic_Location= "F8",
                        Clinic_Phone= "555-1234",
                        AmoutForBook= 1050
                    },

                };
                await _dbContext.Clinics.AddRangeAsync(Clinic);
                await _dbContext.SaveChangesAsync();
            }
            if (!_dbContext.Rooms.Any())
            {
                var rooms = new List<Rooms>
        {
            new Rooms
            {
                RoomNumber = "101",
                RoomType = "Standard",
                RoomStatus = "Occupied",
                RoomPrice = 50,
                Room_Location = "First Floor",
                RoomCapacity = "Single",
                DepartmentId = 1
            },
            new Rooms
            {
                RoomNumber = "201",
                RoomType = "Deluxe",
                RoomStatus = "Vacant",
                RoomPrice = 100,
                Room_Location = "Second Floor",
                RoomCapacity = "Double",
                DepartmentId = 2
            },
            new Rooms
            {
                RoomNumber = "301",
                RoomType = "Standard",
                RoomStatus = "Occupied",
                RoomPrice = 50,
                Room_Location = "Third Floor",
                RoomCapacity = "Single",
                DepartmentId = 3
            },
            new Rooms
            {
                RoomNumber = "401",
                RoomType = "Deluxe",
                RoomStatus = "Vacant",
                RoomPrice = 100,
                Room_Location = "Fourth Floor",
                RoomCapacity = "Double",
                DepartmentId = 4
            },
            new Rooms
            {
                RoomNumber = "501",
                RoomType = "Standard",
                RoomStatus = "Occupied",
                RoomPrice = 50,
                Room_Location = "Fifth Floor",
                RoomCapacity = "Single",
                DepartmentId = 5
            },
            new Rooms
            {
                RoomNumber = "601",
                RoomType = "Deluxe",
                RoomStatus = "Vacant",
                RoomPrice = 100,
                Room_Location = "Sixth Floor",
                RoomCapacity = "Double",
                DepartmentId = 6
            },
            new Rooms
            {
                RoomNumber = "701",
                RoomType = "Standard",
                RoomStatus = "Occupied",
                RoomPrice = 50,
                Room_Location = "Seventh Floor",
                RoomCapacity = "Single",
                DepartmentId = 7
            }
            // Add more rooms as needed
        };

                _dbContext.Rooms.AddRange(rooms);
                await _dbContext.SaveChangesAsync();
            }
            if (!_dbContext.Medications.Any())
            {
                var medications = new List<Medication>
        {
            new Medication
            {
                Medication_Name = "Painkiller",
                medication_Description = "For pain relief",
                Medication_Type = "Tablet",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,
               

            },
            new Medication
            {
                Medication_Name = "Antibiotic",
              
                medication_Description = "For infection",
                Medication_Type = "Capsule",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
               

            },
            new Medication
            {
                Medication_Name = "Vitamin C",
              
                medication_Description = "For immunity",
                Medication_Type = "Tablet",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
             


            },
            new Medication
            {
                Medication_Name = "Antacid",
              
                medication_Description = "For acidity",
                Medication_Type = "Tablet",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
              
            },
            new Medication
            {
                Medication_Name = "SODIUM CHLORIDE",
                
                medication_Description = "For infection",
                Medication_Type = "Solution for injection",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
                
            },
            new Medication
            {
                Medication_Name = "CALCIUM CARBONATE",
                
                medication_Description = "For immunity",
                Medication_Type = "Tablet",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
               
            },
            new Medication
            {
                Medication_Name = "KETOPROFEN",
              
                medication_Description = "For acidity",
                Medication_Type = "Tablet",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
                
            },
            new Medication
            {
                Medication_Name = "SODIUM HYALURONATE",
                medication_Description = "For pain relief",
                Medication_Type = "Tablet",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "ABATACEPT",
                medication_Description = "For infection",
                Medication_Type = "Capsule",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "ACETAMINOPHEN",
                medication_Description = "For immunity",
                Medication_Type = "Tablet",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "CEFPODOXIME",
                medication_Description = "For acidity",
                Medication_Type = "Tablet",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "CLOPIDOGREL",
                medication_Description = "For pain relief",
                Medication_Type = "Tablet",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "CLOTRIMAZOLE",
                medication_Description = "For infection",
                Medication_Type = "Capsule",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "CYCLOSPORINE",
                medication_Description = "For immunity",
                Medication_Type = "Eye drops, suspension\t",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "DILTIAZEM",
                medication_Description = "Eye drops, suspension	",
                Medication_Type = "Tablet",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "DIPHENHYDRAMINE",
                medication_Description = "For pain relief",
                Medication_Type = "Tablet",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "DIVALPROEX",
                medication_Description = "For infection",
                Medication_Type = "Capsule",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "DOCUSATE",
                medication_Description = "For immunity",
                Medication_Type = "Tablet",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "DOXAZOSIN",
                medication_Description = "For acidity",
                Medication_Type = "Injection",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "ENALAPRIL",
                medication_Description = "For pain relief",
                Medication_Type = "Injection",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "ENOXAPARIN",
                medication_Description = "For infection",
                Medication_Type = "Film-coated tablet\t",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "FENOFIBRATE",
                medication_Description = "For immunity",
                Medication_Type = "Film-coated tablet\t",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "FLUCONAZOLE",
                medication_Description = "For acidity",
                Medication_Type = "Solution\t",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "FUROSEMIDE",
                medication_Description = "For pain relief",
                Medication_Type = "Solution\t",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,

            },
            new Medication
            {
                Medication_Name = "GABAPENTIN",
                medication_Description = "For infection",
                Medication_Type = "Solution\t",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "GLIMEPIRIDE",
                medication_Description = "For immunity",
                Medication_Type = "Syrup",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "GLIPIZIDE",
                medication_Description = "For acidity",
                Medication_Type = "Syrup",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "GLYBURIDE",
                medication_Description = "For pain relief",
                Medication_Type = "Tablet",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "HALOPERIDOL",
                medication_Description = "For infection",
                Medication_Type = "Capsule",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "HYDROCHLOROTHIAZIDE",
                medication_Description = "For immunity",
                Medication_Type = "Tablet",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "IBUPROFEN",
                medication_Description = "For acidity",
                Medication_Type = "Tablet",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "INSULIN",
                medication_Description = "For pain relief",
                Medication_Type = "Tablet",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "LANSOPRAZOLE",
                medication_Description = "For infection",
                Medication_Type = "Capsule",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "LEVOTHYROXINE",
                medication_Description = "For immunity",
                Medication_Type = "Tablet",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "LISINOPRIL",
                medication_Description = "For acidity",
                Medication_Type = "Tablet",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "LORATADINE",
                medication_Description = "For pain relief",
                Medication_Type = "Tablet",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "LOSARTAN",
                medication_Description = "For infection",
                Medication_Type = "Capsule",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "MELOXICAM",
                medication_Description = "For immunity",
                Medication_Type = "Tablet",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "METFORMIN",
                medication_Description = "For acidity",
                Medication_Type = "Tablet",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "METHOTREXATE",
                medication_Description = "For pain relief",
                Medication_Type = "Tablet",
                Medication_Quantity = 30,
                medication_Price = 20,
                Expiration_Date = DateTime.Parse("2023-06-30"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "METOPROLOL",
                medication_Description = "For infection",
                Medication_Type = "Capsule",
                Medication_Quantity = 20,
                medication_Price = 15,
                Expiration_Date = DateTime.Parse("2023-08-15"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "MIRTAZAPINE",
                medication_Description = "For immunity",
                Medication_Type = "Tablet",
                Medication_Quantity = 60,
                medication_Price = 10,
                Expiration_Date = DateTime.Parse("2023-12-31"),
                IsAvailable = true,
            },
            new Medication
            {
                Medication_Name = "NAPROXEN",
                medication_Description = "For acidity",
                Medication_Type = "Tablet",
                Medication_Quantity = 40,
                medication_Price = 25,
                Expiration_Date = DateTime.Parse("2023-10-31"),
                IsAvailable = true,
            },

          

            // Add more medications as needed
        };

                _dbContext.Medications.AddRange(medications);
                await _dbContext.SaveChangesAsync();
            }
            if (!_dbContext.Tests.Any())
            {
                var tests = new List<Tests>
        {
            new Tests
            {
                TestName = "(DHEA)",
                TestPrice=150
            },
            new Tests
            {
                TestName = "ACTH",
                TestPrice=160
            },
            new Tests
            {
                TestName = "FSH",
                TestPrice =100
            },
            new Tests
            {
                TestName = "LH",
                TestPrice = 100
            },
            new Tests
            {
                TestName = "TSH",
                TestPrice = 120
            },
            new Tests
            {
                TestName = "Prolactin",
                TestPrice = 130
            },
            new Tests
            {
                TestName = "Cortisol",
                TestPrice = 140
            },
            new Tests
            {
                TestName = "LUPUS ANTI Coagulant time IGM",
                TestPrice = 150
            },
            new Tests
            {
                TestName = "LUPUS ANTI Coagulant time IGG",
                TestPrice = 150
            },
            new Tests
            {
                TestName = "LUPUS ANTI Coagulant time IGA",
                TestPrice = 150
            },
            new Tests
            {
                TestName = "Anti-Mullerian",
                TestPrice = 400
            },
            new Tests
            {
                TestName = "Anti-Cardiolipin",
                TestPrice = 200
            },
            new Tests
            {
                TestName = "Multi drugs (4iems)",
                TestPrice = 300
            },
            new Tests
            {
                TestName = "Benzodiasepines",
                TestPrice = 90
            },
            new Tests
            {
                TestName = "Cyclosporin",
                TestPrice = 120
            },
            new Tests
            {
                TestName = "Phenobarbital",
                TestPrice = 100
            },
            new Tests
            {
                TestName = "Phenytoin",
                TestPrice = 110
            },
            new Tests
            {
                TestName = "P-B OR Monospot",
                TestPrice = 180
            },
            new Tests
            {
                TestName = "HIV 1&2",
                TestPrice = 200
            },
            new Tests
            {
                TestName = "Blood Culture &Sensctivity",
                TestPrice = 250
            },
            new Tests
            {
                TestName = "Cell Count FOR BODY FLUID",
                TestPrice = 250
            },
            new Tests
            {
                TestName = " CSF Exanimation (chemical)",
                TestPrice = 300
            },
            new Tests
            {
                TestName = " CSF Exanimation (microscopic)",
                TestPrice = 300
            },
            new Tests
            {
                TestName = " CSF Exanimation (C/S)",
                TestPrice = 300
            },
            new Tests
            {
                TestName = " Culture for fungi",
                TestPrice = 150
            },
            new Tests
            {
                TestName = "T.B -DNA by - PCR",
                TestPrice = 450
            },
            new Tests
            {
                TestName = "(ABG)",
                TestPrice = 400
            },
            new Tests
            {
                TestName = " Blood Gases",
                TestPrice = 400
            },
            new Tests
            {
                TestName = " Anion gap (Na ;K; CL; HCO3;)",
                TestPrice = 200
            },
            new Tests
            {
                TestName = " Lactic Acid",
                TestPrice = 200
            },
            new Tests
            {
                TestName = " Osmolality",
                TestPrice = 200
            },
            new Tests
            {
                TestName = " Serum Ammonia",
                TestPrice = 200
            },
            new Tests
            {
                TestName = " Serum Lactate",
                TestPrice = 200
            },
            new Tests
            {
                TestName = " Serum Osmolality",
                TestPrice = 200
            },
          
            // Add more tests as needed
        };

                _dbContext.Tests.AddRange(tests);
                await _dbContext.SaveChangesAsync();
            }
            if (!_dbContext.Warehouses.Any())
            {
                var warHouses = new List<warehouse>

                {
                    new warehouse
                    {
                        Item = "Painkiller",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Antibiotic",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-08-15"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Vitamin C",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-12-31"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Antacid",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-10-31"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "DHEA",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "ACTH",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "FSH",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "LH",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "TSH",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Prolactin",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Cortisol",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "LUPUS ANTI Coagulant time IGM",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "LUPUS ANTI Coagulant time IGG",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "LUPUS ANTI Coagulant time IGA",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Anti-Mullerian",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Anti-Cardiolipin",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Multi drugs (4iems)",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Benzodiasepines",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Cyclosporin",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Phenobarbital",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Phenytoin",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "P-B OR Monospot",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "HIV 1&2",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Blood Culture &Sensctivity",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "Cell Count FOR BODY FLUID",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },
                    new warehouse
                    {
                        Item = "CSF Exanimation (chemical)",
                        Quantity = 100,
                        ExpirationDate = DateTime.Parse("2023-06-30"),
                        AvailableQuantity = 100,
                        IsAvailable = true
                    },










                };
                _dbContext.Warehouses.AddRange(warHouses);
                await _dbContext.SaveChangesAsync();
            }
            if (!_dbContext.Digital_X_Rays.Any())
            {
                var Digitalxray = new List<Digital_x_rays>
                {
                    new Digital_x_rays
                    {
                        Name = "Chest X-Ray",
                        Price = 100
                    },
                    new Digital_x_rays
                    {
                        Name = "Abdominal X-Ray",
                        Price = 150
                    },
                    new Digital_x_rays
                    {
                        Name = "Pelvic X-Ray",
                        Price = 200
                    },
                    new Digital_x_rays
                    {
                        Name = "Spinal X-Ray",
                        Price = 250
                    },
                    new Digital_x_rays
                    {
                        Name = "Skull X-Ray",
                        Price = 300
                    },
                    new Digital_x_rays
                    {
                        Name = "Knee X-Ray",
                        Price = 350
                    },
                    new Digital_x_rays
                    {
                        Name = "Shoulder X-Ray",
                        Price = 400
                    },
                    new Digital_x_rays
                    {
                        Name = "Elbow X-Ray",
                        Price = 450
                    },
                    new Digital_x_rays
                    {
                        Name = "Wrist X-Ray",
                        Price = 500
                    },
                    new Digital_x_rays
                    {
                        Name = "Ankle X-Ray",
                        Price = 550
                    },
                    new Digital_x_rays
                    {
                        Name = "Foot X-Ray",
                        Price = 600
                    },
                    new Digital_x_rays
                    {
                        Name = "Hand X-Ray",
                        Price = 650
                    },
                    new Digital_x_rays
                    {
                        Name = "Neck X-Ray",
                        Price = 700
                    },
                    new Digital_x_rays
                    {
                        Name = "Leg X-Ray",
                        Price = 750
                    },
                    new Digital_x_rays
                    {
                        Name = "Arm X-Ray",
                        Price = 800
                    },
                    new Digital_x_rays
                    {
                        Name = "Hip X-Ray",
                        Price = 850
                    },
                    new Digital_x_rays
                    {
                        Name = "Thigh X-Ray",
                        Price = 900
                    },
                    new Digital_x_rays
                    {
                        Name = "Forearm X-Ray",
                        Price = 950
                    },
                    new Digital_x_rays
                    {
                        Name = "Calf X-Ray",
                        Price = 1000
                    },
                    new Digital_x_rays
                    {
                        Name = "Forehead X-Ray",
                        Price = 1050
                    },
                    new Digital_x_rays
                    {
                        Name = "Jaw X-Ray",
                        Price = 1100
                    },
                    new Digital_x_rays
                    {
                        Name = "Chest X-Ray",
                        Price = 1150
                    },
                    new Digital_x_rays
                    {
                        Name = "Abdominal X-Ray",
                        Price = 1200
                    },
                    new Digital_x_rays
                    {
                        Name = "Pelvic X-Ray",
                        Price = 1250
                    },
                    new Digital_x_rays
                    {
                        Name = "Spinal X-Ray",
                        Price = 1300
                    },
                    new Digital_x_rays
                    {
                        Name = "Skull X-Ray",
                        Price = 1350
                    },
                    new Digital_x_rays
                    {
                        Name = "Knee X-Ray",
                        Price = 1400
                    },
                    new Digital_x_rays
                    {
                        Name = "Shoulder X-Ray",
                        Price = 1450
                    },
                    new Digital_x_rays
                    {
                        Name = "Elbow X-Ray",
                        Price = 1500
                    },
                    new Digital_x_rays
                    {
                        Name = "Wrist X-Ray",
                        Price = 1550
                    },
                    new Digital_x_rays
                    {
                        Name = "Ankle X-Ray",
                        Price = 1600
                    },
                    new Digital_x_rays
                    {
                        Name = "Foot X-Ray",
                        Price = 1650
                    },


                };
                _dbContext.Digital_X_Rays.AddRange(Digitalxray);
                await _dbContext.SaveChangesAsync();




            }
        }

    }
}




        
    

        

          