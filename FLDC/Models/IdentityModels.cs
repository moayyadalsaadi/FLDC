﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Graduation_Project.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<AboutCenter> AboutCenters { get; set; }
        public virtual DbSet<CenterAchievement> CenterAchievements { get; set; }
        public virtual DbSet<CenterPhoto> CenterPhotos { get; set; }
        public virtual DbSet<CenterStaff> CenterStaffs { get; set; }
        public virtual DbSet<FAQ> FAQs { get; set; }
        public virtual DbSet<News> Newss { get; set; }
        public virtual DbSet<PresidentWord> PresidentWords { get; set; }
        public virtual DbSet<CenterRule> CenterRules { get; set; }
        public virtual DbSet<ContactUs> ContactUses { get; set; }
    }
}