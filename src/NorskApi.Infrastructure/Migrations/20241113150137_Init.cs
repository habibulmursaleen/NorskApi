using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dictations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiscussionEssays = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Essays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Progress = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSaved = table.Column<bool>(type: "bit", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Essays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrammarRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExplanatoryNotes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RuleType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
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
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalExpressions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MeaningInNorsk = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MeaningInEnglish = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LocalExpressionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalExpressions", x => x.Id);
                });

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
                name: "Podcasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DictationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsRightAnswer = table.Column<bool>(type: "bit", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuizType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjunctions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjunctionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TagType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskWorks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TaskPointer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskWorks", x => x.Id);
                });

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
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Essay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Essay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Essay_Essays_EssayId",
                        column: x => x.EssayId,
                        principalTable: "Essays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EssayRelatedGrammarTopicIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssayRelatedGrammarTopicIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EssayRelatedGrammarTopicIds_Essays_EssayId",
                        column: x => x.EssayId,
                        principalTable: "Essays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EssayTagIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssayTagIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EssayTagIds_Essays_EssayId",
                        column: x => x.EssayId,
                        principalTable: "Essays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Essays_EssayId",
                        column: x => x.EssayId,
                        principalTable: "Essays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roleplays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    EssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roleplays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roleplays_Essays_EssayId",
                        column: x => x.EssayId,
                        principalTable: "Essays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExampleOfRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrammarRuleId_FK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subjunction = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Adverbial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Verb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Object = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Rest = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CorrectSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EnglishSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IncorrectSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TransformationFrom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TransformationTo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GrammarRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleOfRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleOfRules_GrammarRules_GrammarRuleId",
                        column: x => x.GrammarRuleId,
                        principalTable: "GrammarRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exceptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrammarRuleId_FK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CorrectSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IncorrectSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GrammarRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exceptions_GrammarRules_GrammarRuleId",
                        column: x => x.GrammarRuleId,
                        principalTable: "GrammarRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "SpeakingContentIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NorskproveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingContentIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakingContentIds_Norskproves_NorskproveId",
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

            migrationBuilder.CreateTable(
                name: "QuizOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    MultipleChoiceAnswer = table.Column<bool>(type: "bit", nullable: false),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizOptions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordAntonymIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AntonymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "WordSynonymIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SynonymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "IX_Activites_Label",
                table: "Activites",
                column: "Label",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalGrammarTaskIds_NorskproveId",
                table: "AdditionalGrammarTaskIds",
                column: "NorskproveId");

            migrationBuilder.CreateIndex(
                name: "IX_Essay_EssayId",
                table: "Essay",
                column: "EssayId");

            migrationBuilder.CreateIndex(
                name: "IX_EssayRelatedGrammarTopicIds_EssayId",
                table: "EssayRelatedGrammarTopicIds",
                column: "EssayId");

            migrationBuilder.CreateIndex(
                name: "IX_EssayTagIds_EssayId",
                table: "EssayTagIds",
                column: "EssayId");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleOfRules_GrammarRuleId",
                table: "ExampleOfRules",
                column: "GrammarRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_GrammarRuleId",
                table: "Exceptions",
                column: "GrammarRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_GrammarRuleTagIds_GrammarRuleId",
                table: "GrammarRuleTagIds",
                column: "GrammarRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_GrammarTopicTagIds_GrammarTopicId",
                table: "GrammarTopicTagIds",
                column: "GrammarTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ListeningContentIds_NorskproveId",
                table: "ListeningContentIds",
                column: "NorskproveId");

            migrationBuilder.CreateIndex(
                name: "IX_NorskproveTagIds_NorskproveId",
                table: "NorskproveTagIds",
                column: "NorskproveId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_EssayId",
                table: "Paragraphs",
                column: "EssayId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizOptions_QuizId",
                table: "QuizOptions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingContentIds_NorskproveId",
                table: "ReadingContentIds",
                column: "NorskproveId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedGrammarRuleIds_GrammarRuleId",
                table: "RelatedGrammarRuleIds",
                column: "GrammarRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roleplays_EssayId",
                table: "Roleplays",
                column: "EssayId");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceStructure_GrammarRuleId",
                table: "SentenceStructure",
                column: "GrammarRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingContentIds_NorskproveId",
                table: "SpeakingContentIds",
                column: "NorskproveId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Label",
                table: "Tags",
                column: "Label",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordAntonymIds_WordId",
                table: "WordAntonymIds",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordGrammer_WordId",
                table: "WordGrammer",
                column: "WordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordSynonymIds_WordId",
                table: "WordSynonymIds",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordUsageExample_WordId",
                table: "WordUsageExample",
                column: "WordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WritingContentIds_NorskproveId",
                table: "WritingContentIds",
                column: "NorskproveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activites");

            migrationBuilder.DropTable(
                name: "AdditionalGrammarTaskIds");

            migrationBuilder.DropTable(
                name: "Dictations");

            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DropTable(
                name: "Essay");

            migrationBuilder.DropTable(
                name: "EssayRelatedGrammarTopicIds");

            migrationBuilder.DropTable(
                name: "EssayTagIds");

            migrationBuilder.DropTable(
                name: "ExampleOfRules");

            migrationBuilder.DropTable(
                name: "Exceptions");

            migrationBuilder.DropTable(
                name: "GrammarRuleTagIds");

            migrationBuilder.DropTable(
                name: "GrammarTopicTagIds");

            migrationBuilder.DropTable(
                name: "ListeningContentIds");

            migrationBuilder.DropTable(
                name: "LocalExpressions");

            migrationBuilder.DropTable(
                name: "NorskproveTagIds");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropTable(
                name: "Podcasts");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "QuizOptions");

            migrationBuilder.DropTable(
                name: "ReadingContentIds");

            migrationBuilder.DropTable(
                name: "RelatedGrammarRuleIds");

            migrationBuilder.DropTable(
                name: "Roleplays");

            migrationBuilder.DropTable(
                name: "SentenceStructure");

            migrationBuilder.DropTable(
                name: "SpeakingContentIds");

            migrationBuilder.DropTable(
                name: "Subjunctions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TaskWorks");

            migrationBuilder.DropTable(
                name: "WordAntonymIds");

            migrationBuilder.DropTable(
                name: "WordGrammer");

            migrationBuilder.DropTable(
                name: "WordSynonymIds");

            migrationBuilder.DropTable(
                name: "WordUsageExample");

            migrationBuilder.DropTable(
                name: "WritingContentIds");

            migrationBuilder.DropTable(
                name: "GrammarTopics");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Essays");

            migrationBuilder.DropTable(
                name: "GrammarRules");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Norskproves");
        }
    }
}
