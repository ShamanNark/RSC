using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddSubsidyFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Submitted",
                table: "PrdsoList");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOfAttractedSubsidy",
                table: "Events",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOfOwnSubsidy",
                table: "Events",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOfTheRequestedSubsidy",
                table: "Events",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfAttractedSubsidy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AmountOfOwnSubsidy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AmountOfTheRequestedSubsidy",
                table: "Events");

            migrationBuilder.AddColumn<bool>(
                name: "Submitted",
                table: "PrdsoList",
                nullable: false,
                defaultValue: false);
        }
    }
}
