using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GrammarRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedRuleIds",
                table: "GrammarRules");

            migrationBuilder.DropColumn(
                name: "SentenceStructure",
                table: "GrammarRules");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "GrammarRules");

            migrationBuilder.CreateTable(
                name: "GrammarRuleTagIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrammarRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarRuleTagIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrammarRuleTagIds_GrammarRules_GrammarRuleId",
                        column: x => x.GrammarRuleId,
                        principalTable: "GrammarRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedGrammarRuleIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrammarRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedGrammarRuleIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedGrammarRuleIds_GrammarRules_GrammarRuleId",
                        column: x => x.GrammarRuleId,
                        principalTable: "GrammarRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SentenceStructure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GrammarRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentenceStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentenceStructure_GrammarRules_GrammarRuleId",
                        column: x => x.GrammarRuleId,
                        principalTable: "GrammarRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrammarRuleTagIds_GrammarRuleId",
                table: "GrammarRuleTagIds",
                column: "GrammarRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedGrammarRuleIds_GrammarRuleId",
                table: "RelatedGrammarRuleIds",
                column: "GrammarRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceStructure_GrammarRuleId",
                table: "SentenceStructure",
                column: "GrammarRuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrammarRuleTagIds");

            migrationBuilder.DropTable(
                name: "RelatedGrammarRuleIds");

            migrationBuilder.DropTable(
                name: "SentenceStructure");

            migrationBuilder.AddColumn<string>(
                name: "RelatedRuleIds",
                table: "GrammarRules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SentenceStructure",
                table: "GrammarRules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "GrammarRules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
