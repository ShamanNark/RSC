using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddPublicEventInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventStatusId",
                table: "Events",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CodeName = table.Column<string>(type: "text", nullable: true),
                    StatusName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventStatusId",
                table: "Events",
                column: "EventStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events",
                column: "EventStatusId",
                principalTable: "EventStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventStatus");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventStatusId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventStatusId",
                table: "Events");
        }
    }
}
