using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddFieldsToStudentsCouncilTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "StudentsCouncils",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobPhone",
                table: "StudentsCouncils",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "StudentsCouncils",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fax",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "JobPhone",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "StudentsCouncils");
        }
    }
}
