using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddEventStatusesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventStatus",
                table: "EventStatus");

            migrationBuilder.RenameTable(
                name: "EventStatus",
                newName: "EventStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventStatuses",
                table: "EventStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatuses_EventStatusId",
                table: "Events",
                column: "EventStatusId",
                principalTable: "EventStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatuses_EventStatusId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventStatuses",
                table: "EventStatuses");

            migrationBuilder.RenameTable(
                name: "EventStatuses",
                newName: "EventStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventStatus",
                table: "EventStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events",
                column: "EventStatusId",
                principalTable: "EventStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
