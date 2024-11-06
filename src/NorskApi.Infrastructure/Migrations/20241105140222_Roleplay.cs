using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Roleplay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roleplays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(
                        type: "nvarchar(500)",
                        maxLength: 500,
                        nullable: false
                    ),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roleplays", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Roleplays");
        }
    }
}
