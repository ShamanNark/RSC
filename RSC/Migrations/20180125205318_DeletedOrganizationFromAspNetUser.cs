using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class DeletedOrganizationFromAspNetUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniversityName",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "MainPhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Organisation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrganisationPosition",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UniversityWebSite",
                table: "Universities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organisation",
                table: "Asssessors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganisationPosition",
                table: "Asssessors",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniversityWebSite",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Organisation",
                table: "Asssessors");

            migrationBuilder.DropColumn(
                name: "OrganisationPosition",
                table: "Asssessors");

            migrationBuilder.AddColumn<string>(
                name: "UniversityName",
                table: "Universities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainPhoneNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organisation",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganisationPosition",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
