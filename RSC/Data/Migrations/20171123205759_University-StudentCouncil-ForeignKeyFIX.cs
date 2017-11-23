using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class UniversityStudentCouncilForeignKeyFIX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_UniversityDatas_UniversityDataId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_UniversityDataId",
                table: "Universities");

            migrationBuilder.AddColumn<string>(
                name: "UniversityName",
                table: "Universities",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_EducationalOrganizationId",
                table: "Universities",
                column: "EducationalOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_EducationalOrganizationId",
                table: "StudentsCouncils",
                column: "EducationalOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_UniversityDatas_EducationalOrganizationId",
                table: "StudentsCouncils",
                column: "EducationalOrganizationId",
                principalTable: "UniversityDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_UniversityDatas_EducationalOrganizationId",
                table: "Universities",
                column: "EducationalOrganizationId",
                principalTable: "UniversityDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_UniversityDatas_EducationalOrganizationId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_UniversityDatas_EducationalOrganizationId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_EducationalOrganizationId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_EducationalOrganizationId",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "UniversityName",
                table: "Universities");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_UniversityDataId",
                table: "Universities",
                column: "UniversityDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_UniversityDatas_UniversityDataId",
                table: "Universities",
                column: "UniversityDataId",
                principalTable: "UniversityDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
