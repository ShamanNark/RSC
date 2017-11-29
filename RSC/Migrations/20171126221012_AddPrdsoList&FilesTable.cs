using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddPrdsoListFilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_PrdsoTypes_PrdsoTypeId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PrdsoTypeId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PrdsoTypeId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventTypeId",
                table: "Events",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrdsoList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BICCode = table.Column<string>(type: "text", nullable: true),
                    BankINN = table.Column<string>(type: "text", nullable: true),
                    BankKPP = table.Column<string>(type: "text", nullable: true),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    CheckingAccount = table.Column<string>(type: "text", nullable: true),
                    CorrespondentAccount = table.Column<string>(type: "text", nullable: true),
                    EGRULId = table.Column<int>(type: "int4", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Fax = table.Column<string>(type: "text", nullable: true),
                    INN = table.Column<string>(type: "text", nullable: true),
                    KPP = table.Column<string>(type: "text", nullable: true),
                    MailAddress = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    OGRN = table.Column<string>(type: "text", nullable: true),
                    OKPO = table.Column<string>(type: "text", nullable: true),
                    OrderApprovalRectorId = table.Column<int>(type: "int4", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    StudentsCouncilId = table.Column<int>(type: "int4", nullable: false),
                    StudentsCount = table.Column<int>(type: "int4", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    UniversityId = table.Column<int>(type: "int4", nullable: false),
                    UrAddress = table.Column<string>(type: "text", nullable: true),
                    WebSite = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrdsoList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrdsoList_Files_EGRULId",
                        column: x => x.EGRULId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrdsoList_Files_OrderApprovalRectorId",
                        column: x => x.OrderApprovalRectorId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrdsoList_StudentsCouncils_StudentsCouncilId",
                        column: x => x.StudentsCouncilId,
                        principalTable: "StudentsCouncils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrdsoList_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PrdsoId",
                table: "Events",
                column: "PrdsoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrdsoList_EGRULId",
                table: "PrdsoList",
                column: "EGRULId");

            migrationBuilder.CreateIndex(
                name: "IX_PrdsoList_OrderApprovalRectorId",
                table: "PrdsoList",
                column: "OrderApprovalRectorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrdsoList_StudentsCouncilId",
                table: "PrdsoList",
                column: "StudentsCouncilId");

            migrationBuilder.CreateIndex(
                name: "IX_PrdsoList_UniversityId",
                table: "PrdsoList",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_PrdsoTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "PrdsoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_PrdsoList_PrdsoId",
                table: "Events",
                column: "PrdsoId",
                principalTable: "PrdsoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_PrdsoTypes_EventTypeId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_PrdsoList_PrdsoId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "PrdsoList");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventTypeId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PrdsoId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "PrdsoTypeId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

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
    }
}
