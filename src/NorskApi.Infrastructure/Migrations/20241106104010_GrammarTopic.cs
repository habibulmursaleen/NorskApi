using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:src/NorskApi.Infrastructure/Migrations/20241105140222_Roleplay.cs
    public partial class Roleplay : Migration
========
    public partial class GrammarTopic : Migration
>>>>>>>> GrammarTopicsEndpoint:src/NorskApi.Infrastructure/Migrations/20241106104010_GrammarTopic.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
<<<<<<<< HEAD:src/NorskApi.Infrastructure/Migrations/20241105140222_Roleplay.cs
                name: "Roleplays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
========
                name: "GrammarTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chapter = table.Column<double>(type: "float", nullable: false),
                    ModuleCount = table.Column<double>(type: "float", nullable: false),
                    Progress = table.Column<double>(type: "float", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSaved = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
>>>>>>>> GrammarTopicsEndpoint:src/NorskApi.Infrastructure/Migrations/20241106104010_GrammarTopic.cs
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
<<<<<<<< HEAD:src/NorskApi.Infrastructure/Migrations/20241105140222_Roleplay.cs
                    table.PrimaryKey("PK_Roleplays", x => x.Id);
========
                    table.PrimaryKey("PK_GrammarTopics", x => x.Id);
>>>>>>>> GrammarTopicsEndpoint:src/NorskApi.Infrastructure/Migrations/20241106104010_GrammarTopic.cs
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<<< HEAD:src/NorskApi.Infrastructure/Migrations/20241105140222_Roleplay.cs
                name: "Roleplays");
========
                name: "GrammarTopics");
>>>>>>>> GrammarTopicsEndpoint:src/NorskApi.Infrastructure/Migrations/20241106104010_GrammarTopic.cs
        }
    }
}
