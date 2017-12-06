using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Migrations
{
    public partial class AddPublicEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicEventInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DisLikes = table.Column<int>(type: "int4", nullable: false),
                    DistricSMI = table.Column<string>(type: "text", nullable: true),
                    EventHashTags = table.Column<string>(type: "text", nullable: true),
                    EventId = table.Column<int>(type: "int4", nullable: false),
                    EventWebSite = table.Column<string>(type: "text", nullable: true),
                    FacebookGroup = table.Column<string>(type: "text", nullable: true),
                    FederalSMI = table.Column<string>(type: "text", nullable: true),
                    FotoId = table.Column<int>(type: "int4", nullable: true),
                    InstagramGroup = table.Column<string>(type: "text", nullable: true),
                    Likes = table.Column<int>(type: "int4", nullable: false),
                    OOVOWebSite = table.Column<string>(type: "text", nullable: true),
                    RegionalSMI = table.Column<string>(type: "text", nullable: true),
                    ResultVideo = table.Column<string>(type: "text", nullable: true),
                    SmallFotoId = table.Column<int>(type: "int4", nullable: true),
                    StudentSMI = table.Column<string>(type: "text", nullable: true),
                    VKGroup = table.Column<string>(type: "text", nullable: true),
                    VideoEsse = table.Column<string>(type: "text", nullable: true),
                    VideoLink = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicEventInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicEventInformations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicEventInformations_Files_FotoId",
                        column: x => x.FotoId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicEventInformations_Files_SmallFotoId",
                        column: x => x.SmallFotoId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicEventInformations_EventId",
                table: "PublicEventInformations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicEventInformations_FotoId",
                table: "PublicEventInformations",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicEventInformations_SmallFotoId",
                table: "PublicEventInformations",
                column: "SmallFotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicEventInformations");
        }
    }
}
