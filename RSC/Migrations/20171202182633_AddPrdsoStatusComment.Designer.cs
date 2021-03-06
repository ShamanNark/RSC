﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RSC.Data;
using RSC.Data.DbModels;
using RSC.Models;
using System;

namespace RSC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171202182633_AddPrdsoStatusComment")]
    partial class AddPrdsoStatusComment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RSC.Data.DbModels.Assessor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<bool>("ExperienceOfParticipation");

                    b.Property<string>("Job");

                    b.Property<string>("JobPhoneNumber");

                    b.Property<string>("JobPosition");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Asssessors");
                });

            modelBuilder.Entity("RSC.Data.DbModels.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmountCost");

                    b.Property<int>("Count");

                    b.Property<string>("DirectionOfCost");

                    b.Property<int>("EventId");

                    b.Property<string>("Note");

                    b.Property<string>("Unit");

                    b.Property<decimal>("UnitPrice");

                    b.Property<int>("СostDivisionId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("СostDivisionId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("RSC.Data.DbModels.CostDivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CostSectionId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CostSectionId");

                    b.ToTable("CostDivisions");
                });

            modelBuilder.Entity("RSC.Data.DbModels.CostSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CostSections");
                });

            modelBuilder.Entity("RSC.Data.DbModels.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountImplementaionEvents");

                    b.Property<int>("CountOOVO");

                    b.Property<int>("EventDirectionId");

                    b.Property<int>("EventTypeId");

                    b.Property<string>("ExpectedEffectsOfTheEvent")
                        .IsRequired();

                    b.Property<string>("ImplementationEventsShotInfo")
                        .IsRequired();

                    b.Property<string>("ImplementationPlan")
                        .IsRequired();

                    b.Property<string>("MeasuresToEnsurePublicityEvent")
                        .IsRequired();

                    b.Property<string>("NameEvent")
                        .IsRequired();

                    b.Property<int>("NumberOfParticipantsInThisOOVO");

                    b.Property<int>("NumberOfParticipantsWithSubsidies");

                    b.Property<int>("NumberOfParticipantsWithoutSubsidy");

                    b.Property<string>("OrderOfEventManagement")
                        .IsRequired();

                    b.Property<int>("PrdsoId");

                    b.Property<string>("PurposeOfTheEvent")
                        .IsRequired();

                    b.Property<int>("RegionId");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<DateTime>("StopDateTime");

                    b.Property<int>("TotalNumberOfParticipants");

                    b.HasKey("Id");

                    b.HasIndex("EventDirectionId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("PrdsoId");

                    b.HasIndex("RegionId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("RSC.Data.DbModels.EventDirection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EventDirections");
                });

            modelBuilder.Entity("RSC.Data.DbModels.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PrdsoTypes");
                });

            modelBuilder.Entity("RSC.Data.DbModels.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("RSC.Data.DbModels.NewsRubric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("NewsRubrics");
                });

            modelBuilder.Entity("RSC.Data.DbModels.ObjectNewsNewsRubric", b =>
                {
                    b.Property<int>("ObjectNewsId");

                    b.Property<int>("NewsRubricId");

                    b.Property<int>("Id");

                    b.HasKey("ObjectNewsId", "NewsRubricId");

                    b.HasIndex("NewsRubricId");

                    b.ToTable("ListObjectNewsNewsRubric");
                });

            modelBuilder.Entity("RSC.Data.DbModels.Prdso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BICCode");

                    b.Property<string>("BankINN");

                    b.Property<string>("BankKPP");

                    b.Property<string>("BankName");

                    b.Property<string>("CheckingAccount");

                    b.Property<string>("CorrespondentAccount");

                    b.Property<int>("EGRULId");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("INN");

                    b.Property<string>("KPP");

                    b.Property<string>("MailAddress");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<string>("OGRN");

                    b.Property<string>("OKPO");

                    b.Property<int>("OderApprovalRectorId");

                    b.Property<string>("Position");

                    b.Property<string>("PrdsoStatusComment");

                    b.Property<int>("StatusId");

                    b.Property<bool>("StudentCouncilApproved");

                    b.Property<int>("StudentsCouncilId");

                    b.Property<int>("StudentsCount");

                    b.Property<bool>("Submitted");

                    b.Property<string>("Surname");

                    b.Property<bool>("UniversityApproved");

                    b.Property<int>("UniversityId");

                    b.Property<string>("UrAddress");

                    b.Property<string>("WebSite");

                    b.HasKey("Id");

                    b.HasIndex("EGRULId");

                    b.HasIndex("OderApprovalRectorId");

                    b.HasIndex("StatusId");

                    b.HasIndex("StudentsCouncilId");

                    b.HasIndex("UniversityId");

                    b.ToTable("PrdsoList");
                });

            modelBuilder.Entity("RSC.Data.DbModels.PrdsoStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PrdsoStatuses");
                });

            modelBuilder.Entity("RSC.Data.DbModels.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RegionName");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("RSC.Data.DbModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("EducationalOrganizationId");

                    b.Property<int>("Gender");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<int>("RegionId");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("EducationalOrganizationId");

                    b.HasIndex("RegionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("RSC.Data.DbModels.StudentsCouncil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("ConferenceProtocolId");

                    b.Property<int>("EducationalOrganizationId");

                    b.Property<string>("Fax");

                    b.Property<string>("JobPhone");

                    b.Property<string>("MiddleName");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("Name");

                    b.Property<int>("OrderCreationCouncilOfLearnersId");

                    b.Property<int>("ProtocolApprovalStudentAssociationsId");

                    b.Property<int>("RegionId");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ConferenceProtocolId");

                    b.HasIndex("EducationalOrganizationId");

                    b.HasIndex("OrderCreationCouncilOfLearnersId");

                    b.HasIndex("ProtocolApprovalStudentAssociationsId");

                    b.HasIndex("RegionId");

                    b.ToTable("StudentsCouncils");
                });

            modelBuilder.Entity("RSC.Data.DbModels.TargetIndicator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BasicValue");

                    b.Property<int>("EventId");

                    b.Property<string>("Name");

                    b.Property<int>("PlannedValue");

                    b.Property<string>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("TargetIndicators");
                });

            modelBuilder.Entity("RSC.Data.DbModels.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Fax");

                    b.Property<string>("JobPhoneNumber");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<int>("PowerOfAttorneyId");

                    b.Property<int>("RegionId");

                    b.Property<string>("Surname");

                    b.Property<int>("UniversityDataId");

                    b.Property<string>("UniversityForm");

                    b.Property<string>("UniversityName");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PowerOfAttorneyId");

                    b.HasIndex("RegionId");

                    b.HasIndex("UniversityDataId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("RSC.Data.DbModels.UniversityData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RegionId");

                    b.Property<string>("UniversityAddress");

                    b.Property<string>("UniversityName");

                    b.Property<string>("UniversityShortName");

                    b.Property<string>("UniversityWebSite");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("UniversityDatas");
                });

            modelBuilder.Entity("RSC.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RSC.Models.NewsViewModels.ObjectNews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("HomePageImage");

                    b.Property<string>("MainImage");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDateTime");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RSC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RSC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RSC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.Assessor", b =>
                {
                    b.HasOne("RSC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("RSC.Data.DbModels.Cost", b =>
                {
                    b.HasOne("RSC.Data.DbModels.Event", "Event")
                        .WithMany("Costs")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.CostDivision", "СostDivision")
                        .WithMany()
                        .HasForeignKey("СostDivisionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.CostDivision", b =>
                {
                    b.HasOne("RSC.Data.DbModels.CostSection", "CostSection")
                        .WithMany("CostDivisions")
                        .HasForeignKey("CostSectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.Event", b =>
                {
                    b.HasOne("RSC.Data.DbModels.EventDirection", "EventDirection")
                        .WithMany()
                        .HasForeignKey("EventDirectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.Prdso", "Prdso")
                        .WithMany("Events")
                        .HasForeignKey("PrdsoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.ObjectNewsNewsRubric", b =>
                {
                    b.HasOne("RSC.Data.DbModels.NewsRubric", "NewsRubric")
                        .WithMany("ListObjectNewsNewsRubric")
                        .HasForeignKey("NewsRubricId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Models.NewsViewModels.ObjectNews", "ObjectNews")
                        .WithMany("ListObjectNewsNewsRubric")
                        .HasForeignKey("ObjectNewsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.Prdso", b =>
                {
                    b.HasOne("RSC.Data.DbModels.FileModel", "EGRUL")
                        .WithMany()
                        .HasForeignKey("EGRULId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.FileModel", "OrderApprovalRector")
                        .WithMany()
                        .HasForeignKey("OderApprovalRectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.PrdsoStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.StudentsCouncil", "StudentsCouncil")
                        .WithMany()
                        .HasForeignKey("StudentsCouncilId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.Student", b =>
                {
                    b.HasOne("RSC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("RSC.Data.DbModels.UniversityData", "University")
                        .WithMany()
                        .HasForeignKey("EducationalOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.StudentsCouncil", b =>
                {
                    b.HasOne("RSC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("RSC.Data.DbModels.FileModel", "ConferenceProtocol")
                        .WithMany()
                        .HasForeignKey("ConferenceProtocolId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.UniversityData", "University")
                        .WithMany()
                        .HasForeignKey("EducationalOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.FileModel", "OrderCreationCouncilOfLearners")
                        .WithMany()
                        .HasForeignKey("OrderCreationCouncilOfLearnersId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.FileModel", "ProtocolApprovalStudentAssociations")
                        .WithMany()
                        .HasForeignKey("ProtocolApprovalStudentAssociationsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.TargetIndicator", b =>
                {
                    b.HasOne("RSC.Data.DbModels.Event", "Event")
                        .WithMany("TargetIndicators")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.University", b =>
                {
                    b.HasOne("RSC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("RSC.Data.DbModels.FileModel", "PowerOfAttorney")
                        .WithMany()
                        .HasForeignKey("PowerOfAttorneyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RSC.Data.DbModels.UniversityData", "UniversityData")
                        .WithMany()
                        .HasForeignKey("UniversityDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RSC.Data.DbModels.UniversityData", b =>
                {
                    b.HasOne("RSC.Data.DbModels.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
