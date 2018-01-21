using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class PickoutGeneralfieldsInApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Regions_RegionId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Regions_RegionId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Regions_RegionId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_RegionId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_RegionId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_Students_RegionId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "Asssessors");

            migrationBuilder.DropColumn(
                name: "JobPosition",
                table: "Asssessors");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Asssessors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Asssessors");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Asssessors");

            migrationBuilder.AddColumn<int>(
                name: "AvatarId",
                table: "AspNetUsers",
                type: "int4",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainPhoneNumber",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organisation",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganisationPosition",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "AspNetUsers",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelegramLink",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VKLink",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AvatarId",
                table: "AspNetUsers",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegionId",
                table: "AspNetUsers",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Files_AvatarId",
                table: "AspNetUsers",
                column: "AvatarId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Files_AvatarId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AvatarId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RegionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MainPhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Organisation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrganisationPosition",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelegramLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VKLink",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Universities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Universities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Universities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Universities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "StudentsCouncils",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "StudentsCouncils",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StudentsCouncils",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "StudentsCouncils",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "StudentsCouncils",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "Asssessors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobPosition",
                table: "Asssessors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Asssessors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Asssessors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Asssessors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_RegionId",
                table: "Universities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_RegionId",
                table: "StudentsCouncils",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RegionId",
                table: "Students",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Regions_RegionId",
                table: "Students",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_Regions_RegionId",
                table: "StudentsCouncils",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Regions_RegionId",
                table: "Universities",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
