using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DiagnosticMedical.Models
{
    public class BookAppointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        [Display(Name = "Doctor Id")]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "Doctor Name")]
        [DataType(DataType.Text)]
        public string DoctorName { get; set; }

        [Required]
        [Display(Name = "Medicare Service")]
        [DataType(DataType.Text)]
        public string MedicareService { get; set; }

        [Required]
        [Display(Name = "Select Date")]
        [DataType(DataType.Date)]
        public DateTime? SelectDate { get; set; }
        public string Status { get; set; }
    }
}