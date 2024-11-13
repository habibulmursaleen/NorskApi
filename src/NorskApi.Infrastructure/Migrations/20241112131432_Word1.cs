using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Word1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntonymIds",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "SynonymIds",
                table: "Words");

            migrationBuilder.CreateTable(
                name: "WordAntonymIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AntonymIds = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordAntonymIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordAntonymIds_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordSynonymIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SynonymIds = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordSynonymIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordSynonymIds_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordAntonymIds_WordId",
                table: "WordAntonymIds",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordSynonymIds_WordId",
                table: "WordSynonymIds",
                column: "WordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordAntonymIds");

            migrationBuilder.DropTable(
                name: "WordSynonymIds");

            migrationBuilder.AddColumn<string>(
                name: "AntonymIds",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SynonymIds",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
