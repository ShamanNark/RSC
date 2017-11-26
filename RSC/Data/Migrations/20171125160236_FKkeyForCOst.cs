using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class FKkeyForCOst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_CostDivisions_СostDivisionId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "CostDivisionId",
                table: "Costs");

            migrationBuilder.AlterColumn<int>(
                name: "СostDivisionId",
                table: "Costs",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_CostDivisions_СostDivisionId",
                table: "Costs",
                column: "СostDivisionId",
                principalTable: "CostDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_CostDivisions_СostDivisionId",
                table: "Costs");

            migrationBuilder.AlterColumn<int>(
                name: "СostDivisionId",
                table: "Costs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int4");

            migrationBuilder.AddColumn<int>(
                name: "CostDivisionId",
                table: "Costs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_CostDivisions_СostDivisionId",
                table: "Costs",
                column: "СostDivisionId",
                principalTable: "CostDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
