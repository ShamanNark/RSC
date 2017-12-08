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
        public DbSet<UniversityData> UniversityDatas { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<CostSection> CostSections { get; set; }
        public DbSet<CostDivision> CostDivisions { get; set; }
        public DbSet<EventDirection> EventDirections { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TargetIndicator> TargetIndicators { get; set; }
        public DbSet<EventType> PrdsoTypes { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<Prdso> PrdsoList { get; set; }
        public DbSet<PrdsoStatus> PrdsoStatuses { get; set; } 
        public DbSet<PublicEventInformation> PublicEventInformations { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }
        public DbSet<EventState> EventStates { get; set; }

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
