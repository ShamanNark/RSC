using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class RenameAdditionalImageToHomePageImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalImages",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "HomePageImage",
                table: "News",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomePageImage",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalImages",
                table: "News",
                nullable: true);
        }
    }
}
