using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class InitialGameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUTC = table.Column<DateTime>(nullable: false),
                    ModifiedUTC = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUTC = table.Column<DateTime>(nullable: false),
                    ModifiedUTC = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberOfPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUTC = table.Column<DateTime>(nullable: false),
                    ModifiedUTC = table.Column<DateTime>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    OpponentId = table.Column<int>(nullable: false),
                    GameStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_GameStatus_GameStatusId",
                        column: x => x.GameStatusId,
                        principalTable: "GameStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Players_OpponentId",
                        column: x => x.OpponentId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUTC = table.Column<DateTime>(nullable: false),
                    ModifiedUTC = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Board_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Board_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointCoordinate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUTC = table.Column<DateTime>(nullable: false),
                    ModifiedUTC = table.Column<DateTime>(nullable: false),
                    BoardId = table.Column<int>(nullable: false),
                    AxisX = table.Column<int>(nullable: false),
                    AxisY = table.Column<int>(nullable: false),
                    ShipTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointCoordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointCoordinate_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointCoordinate_ShipType_ShipTypeId",
                        column: x => x.ShipTypeId,
                        principalTable: "ShipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Board_GameId",
                table: "Board",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_PlayerId",
                table: "Board",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameStatusId",
                table: "Game",
                column: "GameStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_OpponentId",
                table: "Game",
                column: "OpponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerId",
                table: "Game",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PointCoordinate_BoardId",
                table: "PointCoordinate",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_PointCoordinate_ShipTypeId",
                table: "PointCoordinate",
                column: "ShipTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointCoordinate");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropTable(
                name: "ShipType");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "GameStatus");
        }
    }
}
