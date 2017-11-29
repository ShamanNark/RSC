using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddDowloadFilesToStructures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrdsoList_Files_OrderApprovalRectorId",
                table: "PrdsoList");

            migrationBuilder.DropIndex(
                name: "IX_PrdsoList_OrderApprovalRectorId",
                table: "PrdsoList");

            migrationBuilder.DropColumn(
                name: "OrderApprovalRectorId",
                table: "PrdsoList");

            migrationBuilder.AddColumn<int>(
                name: "PowerOfAttorneyId",
                table: "Universities",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConferenceProtocolId",
                table: "StudentsCouncils",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OderApprovalRectorId",
                table: "PrdsoList",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_PowerOfAttorneyId",
                table: "Universities",
                column: "PowerOfAttorneyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_ConferenceProtocolId",
                table: "StudentsCouncils",
                column: "ConferenceProtocolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils",
                column: "OrderCreationCouncilOfLearnersId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCouncils_ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils",
                column: "ProtocolApprovalStudentAssociationsId");

            migrationBuilder.CreateIndex(
                name: "IX_PrdsoList_OderApprovalRectorId",
                table: "PrdsoList",
                column: "OderApprovalRectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrdsoList_Files_OderApprovalRectorId",
                table: "PrdsoList",
                column: "OderApprovalRectorId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Files_PowerOfAttorneyId",
                table: "Universities",
                column: "PowerOfAttorneyId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrdsoList_Files_OderApprovalRectorId",
                table: "PrdsoList");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Files_ConferenceProtocolId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Files_OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCouncils_Files_ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Files_PowerOfAttorneyId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_PowerOfAttorneyId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_ConferenceProtocolId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCouncils_ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_PrdsoList_OderApprovalRectorId",
                table: "PrdsoList");

            migrationBuilder.DropColumn(
                name: "PowerOfAttorneyId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "ConferenceProtocolId",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "OrderCreationCouncilOfLearnersId",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "ProtocolApprovalStudentAssociationsId",
                table: "StudentsCouncils");

            migrationBuilder.DropColumn(
                name: "OderApprovalRectorId",
                table: "PrdsoList");

            migrationBuilder.AddColumn<int>(
                name: "OrderApprovalRectorId",
                table: "PrdsoList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrdsoList_OrderApprovalRectorId",
                table: "PrdsoList",
                column: "OrderApprovalRectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrdsoList_Files_OrderApprovalRectorId",
                table: "PrdsoList",
                column: "OrderApprovalRectorId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
