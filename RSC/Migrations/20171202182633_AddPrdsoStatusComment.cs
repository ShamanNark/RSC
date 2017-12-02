using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddPrdsoStatusComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrdsoStatusComment",
                table: "PrdsoList",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PrdsoList",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PrdsoStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrdsoStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrdsoList_StatusId",
                table: "PrdsoList",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrdsoList_PrdsoStatuses_StatusId",
                table: "PrdsoList",
                column: "StatusId",
                principalTable: "PrdsoStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrdsoList_PrdsoStatuses_StatusId",
                table: "PrdsoList");

            migrationBuilder.DropTable(
                name: "PrdsoStatuses");

            migrationBuilder.DropIndex(
                name: "IX_PrdsoList_StatusId",
                table: "PrdsoList");

            migrationBuilder.DropColumn(
                name: "PrdsoStatusComment",
                table: "PrdsoList");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PrdsoList");
        }
    }
}
