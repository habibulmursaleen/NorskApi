using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GrammarTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "GrammarTopics");

            migrationBuilder.CreateTable(
                name: "GrammarTopicTagIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrammarTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarTopicTagIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrammarTopicTagIds_GrammarTopics_GrammarTopicId",
                        column: x => x.GrammarTopicId,
                        principalTable: "GrammarTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrammarTopicTagIds_GrammarTopicId",
                table: "GrammarTopicTagIds",
                column: "GrammarTopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrammarTopicTagIds");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "GrammarTopics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
