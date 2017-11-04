using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RSC.Data.Migrations
{
    public partial class CreateTable_RelationShipBetweenNewsRubricObjectNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListObjectNewsNewsRubric",
                columns: table => new
                {
                    ObjectNewsId = table.Column<int>(type: "int4", nullable: false),
                    NewsRubricId = table.Column<int>(type: "int4", nullable: false),
                    Id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListObjectNewsNewsRubric", x => new { x.ObjectNewsId, x.NewsRubricId });
                    table.ForeignKey(
                        name: "FK_ListObjectNewsNewsRubric_NewsRubrics_NewsRubricId",
                        column: x => x.NewsRubricId,
                        principalTable: "NewsRubrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListObjectNewsNewsRubric_News_ObjectNewsId",
                        column: x => x.ObjectNewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListObjectNewsNewsRubric_NewsRubricId",
                table: "ListObjectNewsNewsRubric",
                column: "NewsRubricId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListObjectNewsNewsRubric");
        }
    }
}
