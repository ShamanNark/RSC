using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class EventDefaultStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "EventStatusId",
                table: "Events",
                type: "int4",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events",
                column: "EventStatusId",
                principalTable: "EventStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "EventStatusId",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events",
                column: "EventStatusId",
                principalTable: "EventStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
