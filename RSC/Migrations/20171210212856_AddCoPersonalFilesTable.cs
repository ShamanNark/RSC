using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddCoPersonalFilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoPersonalFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FileId = table.Column<int>(type: "int4", nullable: false),
                    StudentCouncilId = table.Column<int>(type: "int4", nullable: false),
                    StudentsCouncilId = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoPersonalFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoPersonalFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoPersonalFiles_StudentsCouncils_StudentsCouncilId",
                        column: x => x.StudentsCouncilId,
                        principalTable: "StudentsCouncils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoPersonalFiles_FileId",
                table: "CoPersonalFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_CoPersonalFiles_StudentsCouncilId",
                table: "CoPersonalFiles",
                column: "StudentsCouncilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoPersonalFiles");
        }
    }
}
