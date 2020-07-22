using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DiagnosticMedical.Models
{
    public class Medicare
    {
        [Required]
        [Display(Name = "Doctor Id")]
        public int DoctorId { get; set; }
        [Required]
        [Key]
        [Display(Name = "Medicare Service Id")]
        public int MedicareId { get; set; }
        [Required]
        [Display(Name = "Medicare Service Name")]
        [DataType(DataType.Text)]
        public string MedicareServiceName { get; set; }
        [Required]
        [Display(Name = "Eligibility")]
        public string Eligibility { get; set; }
    }
}