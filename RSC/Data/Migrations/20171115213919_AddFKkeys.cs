using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class AddFKkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationalOrganizationId",
                table: "Students",
                column: "EducationalOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_UniversityDatas_EducationalOrganizationId",
                table: "Students",
                column: "EducationalOrganizationId",
                principalTable: "UniversityDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_UniversityDatas_EducationalOrganizationId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_EducationalOrganizationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");
        }
    }
}
