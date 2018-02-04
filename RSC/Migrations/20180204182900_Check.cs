using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class Check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Files_ConferenceProtocolId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Files_OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Files_ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils");

            migrationBuilder.AlterColumn<int>(
                name: "ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils",
                type: "int4",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils",
                type: "int4",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceProtocolId",
                table: "StudentsCouncils",
                type: "int4",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_Files_ConferenceProtocolId",
                table: "StudentsCouncils",
                column: "ConferenceProtocolId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_Files_OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils",
                column: "OrderCreationCouncilOfLearnersId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_Files_ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils",
                column: "ProtocolApprovalStudentAssociationsId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Files_ConferenceProtocolId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Files_OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Files_ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils");

            migrationBuilder.AlterColumn<int>(
                name: "ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceProtocolId",
                table: "StudentsCouncils",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_Files_ConferenceProtocolId",
                table: "StudentsCouncils",
                column: "ConferenceProtocolId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_Files_OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils",
                column: "OrderCreationCouncilOfLearnersId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCouncils_Files_ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils",
                column: "ProtocolApprovalStudentAssociationsId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
