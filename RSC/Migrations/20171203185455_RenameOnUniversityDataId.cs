using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class RenameOnUniversityDataId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_UniversityDatas_EducationalOrganizationId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_UniversityDatas_EducationalOrganizationId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_EducationalOrganizationId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_Students_EducationalOrganizationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EducationalOrganizationId",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "EducationalOrganizationId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "UniversityDataId",
                table: "StudentsCouncils",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniversityDataId",
                table: "Students",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_UniversityDataId",
                table: "StudentsCouncils",
                column: "UniversityDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityDataId",
                table: "Students",
                column: "UniversityDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_UniversityDatas_UniversityDataId",
                table: "Students",
                column: "UniversityDataId",
                principalTable: "UniversityDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_UniversityDatas_UniversityDataId",
                table: "StudentsCouncils",
                column: "UniversityDataId",
                principalTable: "UniversityDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_UniversityDatas_UniversityDataId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_UniversityDatas_UniversityDataId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_UniversityDataId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_Students_UniversityDataId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UniversityDataId",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "UniversityDataId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "EducationalOrganizationId",
                table: "StudentsCouncils",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EducationalOrganizationId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_EducationalOrganizationId",
                table: "StudentsCouncils",
                column: "EducationalOrganizationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_UniversityDatas_EducationalOrganizationId",
                table: "StudentsCouncils",
                column: "EducationalOrganizationId",
                principalTable: "UniversityDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
