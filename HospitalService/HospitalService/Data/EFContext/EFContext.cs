using HospitalService.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.EFContext
{
    public class EFContext : IdentityDbContext<DbUser, DbRole, string, IdentityUserClaim<string>,
    DbUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        { }

        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Sickness> Sicknesses { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<DoctorProfile> DoctorProfiles { get; set; }
        public virtual DbSet<PatientProfile> PatientProfiles { get; set; }
        public virtual DbSet<AdminProfile> AdminProfiles { get; set; }
        public virtual DbSet<VisitRequest> VisitRequests { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<DbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });



                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();



                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
