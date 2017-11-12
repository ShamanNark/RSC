using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class ChangeApplicationUserIdTypeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asssessors_AspNetUsers_ApplicationUserId1",
                table: "Asssessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId1",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_AspNetUsers_ApplicationUserId1",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_AspNetUsers_ApplicationUserId1",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_ApplicationUserId1",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_ApplicationUserId1",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Asssessors_ApplicationUserId1",
                table: "Asssessors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Asssessors");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Universities",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "StudentsCouncils",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Asssessors",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Universities_ApplicationUserId",
                table: "Universities",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_ApplicationUserId",
                table: "StudentsCouncils",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Asssessors_ApplicationUserId",
                table: "Asssessors",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asssessors_AspNetUsers_ApplicationUserId",
                table: "Asssessors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_AspNetUsers_ApplicationUserId",
                table: "StudentsCouncils",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_AspNetUsers_ApplicationUserId",
                table: "Universities",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asssessors_AspNetUsers_ApplicationUserId",
                table: "Asssessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_AspNetUsers_ApplicationUserId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_AspNetUsers_ApplicationUserId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_ApplicationUserId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_ApplicationUserId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Asssessors_ApplicationUserId",
                table: "Asssessors");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Universities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Universities",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "StudentsCouncils",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "StudentsCouncils",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Asssessors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Asssessors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_ApplicationUserId1",
                table: "Universities",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_ApplicationUserId1",
                table: "StudentsCouncils",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId1",
                table: "Students",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Asssessors_ApplicationUserId1",
                table: "Asssessors",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Asssessors_AspNetUsers_ApplicationUserId1",
                table: "Asssessors",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId1",
                table: "Students",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_AspNetUsers_ApplicationUserId1",
                table: "StudentsCouncils",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_AspNetUsers_ApplicationUserId1",
                table: "Universities",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
