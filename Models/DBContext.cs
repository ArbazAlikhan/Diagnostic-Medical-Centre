using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DiagnosticMedical.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=DBContext")
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Medicare> Medicares { get; set; }
        public DbSet<BookAppointment> BookAppointments { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

    }
}