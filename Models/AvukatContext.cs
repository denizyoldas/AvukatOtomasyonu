using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AvukatOtomasyonu.Models
{
    public class AvukatContext : DbContext
    {
        public AvukatContext() : base("sqlim")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
    }
}