using NorskApi.Domain.Common.Models;
using NorskApi.Domain.WordAggregate.ValueObjects;

namespace NorskApi.Domain.WordAggregate.Entites;

public sealed class WordUsageExample : Entity<WordUsageExampleId>
{
    public WordId? WordId_FK { get; set; }
    public string? CorrectSentence { get; set; }
    public string? IncorrectSentence { get; set; }
    public string? EnglishSentence { get; set; }
    public string? NewSentence { get; set; }

    private WordUsageExample() { }

    private WordUsageExample(
        WordUsageExampleId id,
        WordId? wordId,
        string? correctSentence,
        string? incorrectSentence,
        string? englishSentence,
        string? newSentence
    )
        : base(id)
    {
        this.WordId_FK = wordId;
        this.CorrectSentence = correctSentence;
        this.IncorrectSentence = incorrectSentence;
        this.EnglishSentence = englishSentence;
        this.NewSentence = newSentence;
    }

    public static WordUsageExample Create(
        WordId? wordId,
        string? correctSentence,
        string? incorrectSentence,
        string? englishSentence,
        string? newSentence
    )
    {
        WordUsageExample wordUsageExample = new WordUsageExample(
            WordUsageExampleId.CreateUnique(),
            wordId,
            correctSentence,
            incorrectSentence,
            englishSentence,
            newSentence
        );

        return wordUsageExample;
    }

    public void Update(
        WordId? wordId,
        string? correctSentence,
        string? incorrectSentence,
        string? englishSentence,
        string? newSentence
    )
    {
        this.WordId_FK = wordId;
        this.CorrectSentence = correctSentence;
        this.IncorrectSentence = incorrectSentence;
        this.EnglishSentence = englishSentence;
        this.NewSentence = newSentence;
    }
}
