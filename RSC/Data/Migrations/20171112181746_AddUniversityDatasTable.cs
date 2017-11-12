using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class AddUniversityDatasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversityDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ApplicationUserId = table.Column<int>(type: "int4", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<int>(type: "int4", nullable: false),
                    UniversityAddress = table.Column<string>(type: "text", nullable: true),
                    UniversityName = table.Column<string>(type: "text", nullable: true),
                    UniversityShortName = table.Column<string>(type: "text", nullable: true),
                    UniversityWebSite = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityDatas_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityDatas_ApplicationUserId1",
                table: "UniversityDatas",
                column: "ApplicationUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityDatas");
        }
    }
}
