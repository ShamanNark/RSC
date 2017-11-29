using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class PrdsoSaveFileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrdsoList_Files_EGRULId",
                table: "PrdsoList");

            migrationBuilder.AlterColumn<int>(
                name: "EGRULId",
                table: "PrdsoList",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrdsoList_Files_EGRULId",
                table: "PrdsoList",
                column: "EGRULId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrdsoList_Files_EGRULId",
                table: "PrdsoList");

            migrationBuilder.AlterColumn<int>(
                name: "EGRULId",
                table: "PrdsoList",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int4");

            migrationBuilder.AddForeignKey(
                name: "FK_PrdsoList_Files_EGRULId",
                table: "PrdsoList",
                column: "EGRULId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
