using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class AddFieldstoUniversityDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Universities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Universities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Universities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Universities",
                type: "text",
                nullable: true);

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
                name: "Fax",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "UniversityDataId",
                table: "Universities");
        }
    }
}
