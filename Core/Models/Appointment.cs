using Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
        public class Appointment : Base
        {
            public int? DoctorId { set; get; }
            public Doctor Doctor { get; set; }
            public int? PatientId { set; get; }
            public Patient Patient { get; set; }
            public DateTime AppointmentDateTime { get; set; } = DateTime.Now;
            public TimeSpan AppointmentTime { get; set; }
            public int AppointmentCount { get; set; }
            public string SelectedDay { get; set; }
        }
}
