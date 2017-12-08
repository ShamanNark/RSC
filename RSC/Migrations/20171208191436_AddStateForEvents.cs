using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddStateForEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PublicEventInformations_EventId",
                table: "PublicEventInformations");

            migrationBuilder.AddColumn<int>(
                name: "EventStateId",
                table: "Events",
                type: "int4",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CodeName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicEventInformations_EventId",
                table: "PublicEventInformations",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventStateId",
                table: "Events",
                column: "EventStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStates_EventStateId",
                table: "Events",
                column: "EventStateId",
                principalTable: "EventStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStates_EventStateId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventStates");

            migrationBuilder.DropIndex(
                name: "IX_PublicEventInformations_EventId",
                table: "PublicEventInformations");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventStateId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventStateId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_PublicEventInformations_EventId",
                table: "PublicEventInformations",
                column: "EventId");
        }
    }
}
