using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class ChangeStructurePublicInfoinNewsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicEventInformations_Files_FotoId",
                table: "PublicEventInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicEventInformations_Files_SmallFotoId",
                table: "PublicEventInformations");

            migrationBuilder.AlterColumn<int>(
                name: "SmallFotoId",
                table: "PublicEventInformations",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FotoId",
                table: "PublicEventInformations",
                type: "int4",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicEventInformations_Files_FotoId",
                table: "PublicEventInformations",
                column: "FotoId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicEventInformations_Files_SmallFotoId",
                table: "PublicEventInformations",
                column: "SmallFotoId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicEventInformations_Files_FotoId",
                table: "PublicEventInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicEventInformations_Files_SmallFotoId",
                table: "PublicEventInformations");

            migrationBuilder.AlterColumn<int>(
                name: "SmallFotoId",
                table: "PublicEventInformations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int4");

            migrationBuilder.AlterColumn<int>(
                name: "FotoId",
                table: "PublicEventInformations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int4");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicEventInformations_Files_FotoId",
                table: "PublicEventInformations",
                column: "FotoId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicEventInformations_Files_SmallFotoId",
                table: "PublicEventInformations",
                column: "SmallFotoId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
