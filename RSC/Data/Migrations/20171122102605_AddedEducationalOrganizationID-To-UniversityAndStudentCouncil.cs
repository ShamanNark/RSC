using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class AddedEducationalOrganizationIDToUniversityAndStudentCouncil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniversityName",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "EducationalOrganization",
                table: "StudentsCouncils");

            migrationBuilder.AddColumn<int>(
                name: "EducationalOrganizationId",
                table: "Universities",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EducationalOrganizationId",
                table: "StudentsCouncils",
                type: "int4",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationalOrganizationId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "EducationalOrganizationId",
                table: "StudentsCouncils");

            migrationBuilder.AddColumn<string>(
                name: "UniversityName",
                table: "Universities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationalOrganization",
                table: "StudentsCouncils",
                nullable: true);
        }
    }
}
