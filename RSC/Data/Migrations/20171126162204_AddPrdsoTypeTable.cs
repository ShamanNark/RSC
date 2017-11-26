using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class AddPrdsoTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRDSOId",
                table: "Events",
                newName: "PrdsoId");

            migrationBuilder.AddColumn<int>(
                name: "PrdsoTypeId",
                table: "Events",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PrdsoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrdsoTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_PrdsoTypeId",
                table: "Events",
                column: "PrdsoTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_PrdsoTypes_PrdsoTypeId",
                table: "Events",
                column: "PrdsoTypeId",
                principalTable: "PrdsoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_PrdsoTypes_PrdsoTypeId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "PrdsoTypes");

            migrationBuilder.DropIndex(
                name: "IX_Events_PrdsoTypeId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PrdsoTypeId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "PrdsoId",
                table: "Events",
                newName: "PRDSOId");
        }
    }
}
