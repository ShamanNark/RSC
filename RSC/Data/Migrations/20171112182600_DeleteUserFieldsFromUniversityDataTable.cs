using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class DeleteUserFieldsFromUniversityDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniversityDatas_AspNetUsers_ApplicationUserId1",
                table: "UniversityDatas");

            migrationBuilder.DropIndex(
                name: "IX_UniversityDatas_ApplicationUserId1",
                table: "UniversityDatas");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UniversityDatas");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "UniversityDatas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "UniversityDatas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UniversityDatas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UniversityDatas_ApplicationUserId1",
                table: "UniversityDatas",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityDatas_AspNetUsers_ApplicationUserId1",
                table: "UniversityDatas",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
