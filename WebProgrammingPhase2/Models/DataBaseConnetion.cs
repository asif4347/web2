using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebProgrammingPhase2.Models
{
    public class DataBaseConnetion:DbContext
    {
        public DbSet<Applicant> ApplicantDb { get; set; }

        public System.Data.Entity.DbSet<WebProgrammingPhase2.Models.AdminContact> AdminContacts { get; set; }
        public DbSet<HRPersonnel> HRPersonnel { get; set; }
    }
}