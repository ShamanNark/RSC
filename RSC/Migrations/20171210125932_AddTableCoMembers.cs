using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddTableCoMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    JobPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    MidleName = table.Column<string>(type: "text", nullable: true),
                    MobilePhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StudentsCouncilId = table.Column<int>(type: "int4", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoMembers_StudentsCouncils_StudentsCouncilId",
                        column: x => x.StudentsCouncilId,
                        principalTable: "StudentsCouncils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoMembers_StudentsCouncilId",
                table: "CoMembers",
                column: "StudentsCouncilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoMembers");
        }
    }
}
