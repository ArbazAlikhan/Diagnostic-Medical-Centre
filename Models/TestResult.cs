using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DiagnosticMedical.Models
{
    public class TestResult
    {
        [Key]
        [Display(Name = "Test Id")]
        public int TestId { get; set; }

        [Display(Name = "Appointment Id")]
        public int AppointmentId { get; set; }

        [Display(Name = "Doctor Id")]
        public int DoctorId { get; set; }

        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }


        [Display(Name = "Select Date")]
        public DateTime Date { get; set; }


        [Display(Name = "Medicare Service")]
        public string MedicareService { get; set; }

        [Display(Name = "Test Value")]
        public int TestValue { get; set; }

        [Display(Name = "Basic Value")]
        public string NormalValue { get; set; }
    }
}