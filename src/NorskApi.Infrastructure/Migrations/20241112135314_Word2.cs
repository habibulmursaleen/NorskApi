using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Word2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SynonymIds",
                table: "WordSynonymIds",
                newName: "SynonymId");

            migrationBuilder.RenameColumn(
                name: "AntonymIds",
                table: "WordAntonymIds",
                newName: "AntonymId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SynonymId",
                table: "WordSynonymIds",
                newName: "SynonymIds");

            migrationBuilder.RenameColumn(
                name: "AntonymId",
                table: "WordAntonymIds",
                newName: "AntonymIds");
        }
    }
}
