using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class AddedEventsAndTargetIndicatorsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Costs",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountImplementaionEvents = table.Column<int>(type: "int4", nullable: false),
                    CountOOVO = table.Column<int>(type: "int4", nullable: false),
                    EventDirectionId = table.Column<int>(type: "int4", nullable: false),
                    ExpectedEffectsOfTheEvent = table.Column<string>(type: "text", nullable: false),
                    ImplementationEventsShotInfo = table.Column<string>(type: "text", nullable: false),
                    ImplementationPlan = table.Column<string>(type: "text", nullable: false),
                    MeasuresToEnsurePublicityEvent = table.Column<string>(type: "text", nullable: false),
                    NameEvent = table.Column<string>(type: "text", nullable: false),
                    NumberOfParticipantsInThisOOVO = table.Column<int>(type: "int4", nullable: false),
                    NumberOfParticipantsWithSubsidies = table.Column<int>(type: "int4", nullable: false),
                    NumberOfParticipantsWithoutSubsidy = table.Column<int>(type: "int4", nullable: false),
                    OrderOfEventManagement = table.Column<string>(type: "text", nullable: false),
                    PRDSOId = table.Column<int>(type: "int4", nullable: false),
                    PurposeOfTheEvent = table.Column<string>(type: "text", nullable: false),
                    RegionId = table.Column<int>(type: "int4", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp", nullable: false),
                    StopDateTime = table.Column<DateTime>(type: "timestamp", nullable: false),
                    TotalNumberOfParticipants = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventDirections_EventDirectionId",
                        column: x => x.EventDirectionId,
                        principalTable: "EventDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BasicValue = table.Column<int>(type: "int4", nullable: false),
                    EventId = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PlannedValue = table.Column<int>(type: "int4", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetIndicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetIndicators_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_EventId",
                table: "Costs",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventDirectionId",
                table: "Events",
                column: "EventDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_RegionId",
                table: "Events",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetIndicators_EventId",
                table: "TargetIndicators",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Events_EventId",
                table: "Costs",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Events_EventId",
                table: "Costs");

            migrationBuilder.DropTable(
                name: "TargetIndicators");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Costs_EventId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Costs");
        }
    }
}
