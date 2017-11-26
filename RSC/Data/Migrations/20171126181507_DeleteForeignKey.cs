using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class DeleteForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_UniversityDatas_EducationalOrganizationId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_EducationalOrganizationId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "EducationalOrganizationId",
                table: "Universities");

            migrationBuilder.AddColumn<int>(
                name: "UniversityDataId",
                table: "Universities",
                type: "int4",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_UniversityDatas_UniversityDataId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_UniversityDataId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "UniversityDataId",
                table: "Universities");

            migrationBuilder.AddColumn<int>(
                name: "EducationalOrganizationId",
                table: "Universities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_EducationalOrganizationId",
                table: "Universities",
                column: "EducationalOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_UniversityDatas_EducationalOrganizationId",
                table: "Universities",
                column: "EducationalOrganizationId",
                principalTable: "UniversityDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
