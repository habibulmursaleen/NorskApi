using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Words : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Meaning = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EnTranslation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NativeMeaning = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PartOfSpeechTag = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    SynonymIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntonymIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordGrammer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId_FK = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GenderMasculine = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GenderFeminine = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GenderNeutral = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SingularDefinitiv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SingularIndefinitiv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PluralDefinitiv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PluralIndefinitiv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Infinitiv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PresentTense = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PastTense = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PresentPerfectTense = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FutureTense = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Positive = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comparative = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Superlative = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SuperlativeDetermined = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PastParticiple = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PresentParticiple = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Irregular = table.Column<bool>(type: "bit", nullable: true),
                    StrongVerb = table.Column<bool>(type: "bit", nullable: true),
                    WeakVerb = table.Column<bool>(type: "bit", nullable: true),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordGrammer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordGrammer_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordUsageExample",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId_FK = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CorrectSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IncorrectSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EnglishSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NewSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordUsageExample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordUsageExample_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordGrammer_WordId",
                table: "WordGrammer",
                column: "WordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordUsageExample_WordId",
                table: "WordUsageExample",
                column: "WordId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordGrammer");

            migrationBuilder.DropTable(
                name: "WordUsageExample");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
