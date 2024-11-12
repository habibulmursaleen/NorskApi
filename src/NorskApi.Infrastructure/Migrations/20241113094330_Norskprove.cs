using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Norskprove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Norskproves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSaved = table.Column<bool>(type: "bit", nullable: false),
                    Progress = table.Column<double>(type: "float", nullable: false),
                    TimeLimit = table.Column<double>(type: "float", nullable: false),
                    EstimatedCompletionTime = table.Column<double>(type: "float", nullable: false),
                    Attempts = table.Column<double>(type: "float", nullable: false),
                    MaxScore = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norskproves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalGrammarTaskIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskWorkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NorskproveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalGrammarTaskIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalGrammarTaskIds_Norskproves_NorskproveId",
                        column: x => x.NorskproveId,
                        principalTable: "Norskproves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListeningContentIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NorskproveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeningContentIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListeningContentIds_Norskproves_NorskproveId",
                        column: x => x.NorskproveId,
                        principalTable: "Norskproves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NorskproveTagIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NorskproveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NorskproveTagIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NorskproveTagIds_Norskproves_NorskproveId",
                        column: x => x.NorskproveId,
                        principalTable: "Norskproves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingContentIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NorskproveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingContentIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingContentIds_Norskproves_NorskproveId",
                        column: x => x.NorskproveId,
                        principalTable: "Norskproves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WritingContentIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscussionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NorskproveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingContentIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WritingContentIds_Norskproves_NorskproveId",
                        column: x => x.NorskproveId,
                        principalTable: "Norskproves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalGrammarTaskIds_NorskproveId",
                table: "AdditionalGrammarTaskIds",
                column: "NorskproveId");

            migrationBuilder.CreateIndex(
                name: "IX_ListeningContentIds_NorskproveId",
                table: "ListeningContentIds",
                column: "NorskproveId");

            migrationBuilder.CreateIndex(
                name: "IX_NorskproveTagIds_NorskproveId",
                table: "NorskproveTagIds",
                column: "NorskproveId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingContentIds_NorskproveId",
                table: "ReadingContentIds",
                column: "NorskproveId");

            migrationBuilder.CreateIndex(
                name: "IX_WritingContentIds_NorskproveId",
                table: "WritingContentIds",
                column: "NorskproveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalGrammarTaskIds");

            migrationBuilder.DropTable(
                name: "ListeningContentIds");

            migrationBuilder.DropTable(
                name: "NorskproveTagIds");

            migrationBuilder.DropTable(
                name: "ReadingContentIds");

            migrationBuilder.DropTable(
                name: "WritingContentIds");

            migrationBuilder.DropTable(
                name: "Norskproves");
        }
    }
}
