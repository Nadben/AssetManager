using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManager.Api.Migrations
{
    public partial class AssetManagerMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recorders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recorders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recorders_Assets_Id",
                        column: x => x.Id,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecorderId = table.Column<Guid>(type: "uuid", nullable: true),
                    RecorderId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cameras_Assets_Id",
                        column: x => x.Id,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cameras_Recorders_RecorderId",
                        column: x => x.RecorderId,
                        principalTable: "Recorders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cameras_Recorders_RecorderId1",
                        column: x => x.RecorderId1,
                        principalTable: "Recorders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_RecorderId",
                table: "Cameras",
                column: "RecorderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_RecorderId1",
                table: "Cameras",
                column: "RecorderId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cameras");

            migrationBuilder.DropTable(
                name: "Recorders");
        }
    }
}
