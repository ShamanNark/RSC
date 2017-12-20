using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class CreateEventSubscribesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventSubscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    PublicEventInformationId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSubscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSubscribers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventSubscribers_PublicEventInformations_PublicEventInformationId",
                        column: x => x.PublicEventInformationId,
                        principalTable: "PublicEventInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSubscribers_ApplicationUserId",
                table: "EventSubscribers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSubscribers_PublicEventInformationId",
                table: "EventSubscribers",
                column: "PublicEventInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSubscribers");
        }
    }
}
