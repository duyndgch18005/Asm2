using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models.Entity6;
namespace WebApplication2.EF
{
    public class AsmContext : DbContext
    {
        public AsmContext() : base("BwConnection")
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Trainees> Trainees { get; set; }
        public DbSet<Trainner> Trainner { get; set; }
        public DbSet<StaffTrainner> StaffTrainner { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CategoryofCourse> CategoryofCourse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) // override DbContext's
        {
            modelBuilder.Entity<Admin>()
                                .ToTable("Admin"); //table name in db

            modelBuilder.Entity<Admin>()
                        .HasKey<int>(b => b.Id);  //setup PK

            // title varchar(50)
            modelBuilder.Entity<Trainees>()
                               .ToTable("Trainees"); //table name in db

            modelBuilder.Entity<Trainees>()
                        .HasKey<int>(b => b.Id);  //setup PK

            // title varchar(50)
            modelBuilder.Entity<Trainner>()
                               .ToTable("Trainner"); //table name in db

            modelBuilder.Entity<Trainner>()
                        .HasKey<int>(b => b.Id);  //setup PK

            // title varchar(50)
            modelBuilder.Entity<StaffTrainner>()
                               .ToTable("StaffTrainner"); //table name in db

            modelBuilder.Entity<StaffTrainner>()
                        .HasKey<int>(b => b.Id);  //setup PK

            // title varchar(50)
            modelBuilder.Entity<Course>()
                               .ToTable("Course"); //table name in db

            modelBuilder.Entity<Course>()
                        .HasKey<int>(b => b.Id);  //setup PK

            // title varchar(50)
            modelBuilder.Entity<CategoryofCourse>()
                               .ToTable("CategoryofCourse"); //table name in db

            modelBuilder.Entity<CategoryofCourse>()
                        .HasKey<int>(b => b.Id);  //setup PK

            // title varchar(50)

        }
    }
}