using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RSC.Models;
using RSC.Models.NewsViewModels;
using RSC.Data.DbModels;

namespace RSC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ObjectNews> News { get; set; }
        public DbSet<NewsRubric> NewsRubrics { get; set; }
        public DbSet<ObjectNewsNewsRubric> ListObjectNewsNewsRubric { get; set;}
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentsCouncil> StudentsCouncils { get; set; }
        public DbSet<Assessor> Asssessors { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ObjectNewsNewsRubric>()
           .HasKey(t => new { t.ObjectNewsId, t.NewsRubricId });

            modelBuilder.Entity<ObjectNewsNewsRubric>()
                .HasOne(sc => sc.NewsRubric)
                .WithMany(s => s.ListObjectNewsNewsRubric)
                .HasForeignKey(sc => sc.NewsRubricId);

            modelBuilder.Entity<ObjectNewsNewsRubric>()
                .HasOne(sc => sc.ObjectNews)
                .WithMany(c => c.ListObjectNewsNewsRubric)
                .HasForeignKey(sc => sc.ObjectNewsId);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
