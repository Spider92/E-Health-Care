using E_Health.Models.Doctor;
using E_Health.Models.Account;
using E_Health.Models.Admin;
using E_Health.Models.UserInRoom;
using E_Health.Models.FA;
using E_Health.Models.Patient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using E_Health.Models.Information;

namespace E_Health.Models.DataContext
{
    public class DoctorContext : DbContext
    {
        public DbSet<Register> Registers { get; set; }
        public DbSet<FirstAid> FirstAids { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<RoomUser> RoomUsers { get; set; }
        public DbSet<Doctors> Docs { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<LatestNews> LatestNewss { get; set; }
        public DbSet<Health_Tips> Tips { get; set; }
        public DbSet<Health_Banner> Banners { get; set; }
        public DbSet<Blocked_Medicine> Medicines { get; set; }
        public DbSet<Report> Reports { get; set; }
              
    }
}