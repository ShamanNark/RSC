using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddedApprovedFieldsInPrdso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StudentCouncilApproved",
                table: "PrdsoList",
                type: "bool",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UniversityApproved",
                table: "PrdsoList",
                type: "bool",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentCouncilApproved",
                table: "PrdsoList");

            migrationBuilder.DropColumn(
                name: "UniversityApproved",
                table: "PrdsoList");
        }
    }
}
