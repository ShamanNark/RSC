using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class AddedRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RegionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityDatas_RegionId",
                table: "UniversityDatas",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_RegionId",
                table: "Universities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_RegionId",
                table: "StudentsCouncils",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RegionId",
                table: "Students",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Regions_RegionId",
                table: "Students",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_Regions_RegionId",
                table: "StudentsCouncils",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Regions_RegionId",
                table: "Universities",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityDatas_Regions_RegionId",
                table: "UniversityDatas",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Regions_RegionId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Regions_RegionId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Regions_RegionId",
                table: "Universities");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityDatas_Regions_RegionId",
                table: "UniversityDatas");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_UniversityDatas_RegionId",
                table: "UniversityDatas");

            migrationBuilder.DropIndex(
                name: "IX_Universities_RegionId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_RegionId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_Students_RegionId",
                table: "Students");
        }
    }
}
