
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.Entities.WordAggregate.Events.DomainEvent;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.WordAggregate.Entites;
using NorskApi.Domain.WordAggregate.Enums;
using NorskApi.Domain.WordAggregate.ValueObjects;

namespace NorskApi.Domain.WordAggregate;

public sealed class Word : AggregateRoot<WordId, Guid>
{
    public EssayId? EssayId { get; set; }
    public string? Title { get; set; }
    public string? Meaning { get; set; }
    public string? EnTranslation { get; set; }
    public string? NativeMeaning { get; set; } // user input 
    public WordType Type { get; set; } // Enum: LOCAL, ACADEMIC, FORMAL, INFORMAL, SLANG, PHRASE
    public PartOfSpeechTag PartOfSpeechTag { get; set; } // Enum: NOUN, PRONOUN, ADVERB, etc.
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<WordId>? synonymIds { get; set; }
    public List<WordId>? AntonymIds { get; set; }
    public WordGrammer? WordGrammer { get; set; }
    public WordUsageExample? WordUsageExample { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Word() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Word(
        WordId wordId,
        EssayId essayId,
        string title,
        string meaning,
        string enTranslation,
        string nativeMeaning,
        WordType type,
        PartOfSpeechTag partOfSpeechTag,
        DifficultyLevel difficultyLevel,
        bool isCompleted,
        DateTime createdAt,
        DateTime updatedAt,
        List<WordId> synonymIds,
        List<WordId> antonymIds,
        WordGrammer wordGrammer,
        WordUsageExample wordUsageExample
    ) : base(wordId)
    {
        this.EssayId = essayId;
        this.Title = title;
        this.Meaning = meaning;
        this.EnTranslation = enTranslation;
        this.NativeMeaning = nativeMeaning;
        this.Type = type;
        this.PartOfSpeechTag = partOfSpeechTag;
        this.DifficultyLevel = difficultyLevel;
        this.IsCompleted = isCompleted;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
        this.synonymIds = synonymIds;
        this.AntonymIds = antonymIds;
        this.WordGrammer = wordGrammer;
        this.WordUsageExample = wordUsageExample;
    }

    public static Word Create(
        EssayId essayId,
        string title,
        string meaning,
        string enTranslation,
        string nativeMeaning,
        WordType type,
        PartOfSpeechTag partOfSpeechTag,
        DifficultyLevel difficultyLevel,
        List<WordId> synonymIds,
        List<WordId> antonymIds,
        WordGrammer wordGrammer,
        WordUsageExample wordUsageExample
    )
    {
        Word word = new Word(
            WordId.CreateUnique(),
            essayId,
            title,
            meaning,
            enTranslation,
            nativeMeaning,
            type,
            partOfSpeechTag,
            difficultyLevel,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            synonymIds,
            antonymIds,
            wordGrammer,
            wordUsageExample
        );

        word.AddDomainEvent(new WordCreatedDomainEvent(word));

        return word;
    }

    public void Update(
        EssayId essayId,
        string title,
        string meaning,
        string enTranslation,
        string nativeMeaning,
        WordType type,
        PartOfSpeechTag partOfSpeechTag,
        DifficultyLevel difficultyLevel,
        List<WordId> synonymIds,
        List<WordId> antonymIds,
        WordGrammer wordGrammer,
        WordUsageExample wordUsageExample,
        DateTime updatedAt
    )
    {
        this.EssayId = essayId;
        this.Title = title;
        this.Meaning = meaning;
        this.EnTranslation = enTranslation;
        this.NativeMeaning = nativeMeaning;
        this.Type = type;
        this.PartOfSpeechTag = partOfSpeechTag;
        this.DifficultyLevel = difficultyLevel;
        this.synonymIds = synonymIds;
        this.AntonymIds = antonymIds;
        this.WordGrammer = wordGrammer;
        this.WordUsageExample = wordUsageExample;
        this.UpdatedAt = updatedAt;

        this.AddDomainEvent(new WordUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new WordDeletedDomainEvent(this));
    }

}