using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DictationId",
                table: "Quizzes",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DictationId",
                table: "Quizzes");
        }
    }
}
