public class Word
{
    public Guid Id { get; set; }
    public Guid EssayId { get; set; }
    public string Title { get; set; }
    public string Meaning { get; set; }
    public string EnTranslation { get; set; }
    public string NativeMeaning { get; set; }
    public WordType Type { get; set; } // Enum: LOCAL, ACADEMIC, FORMAL, INFORMAL, SLANG, PHRASE
    public PartOfSpeechTag PartOfSpeechTag { get; set; } // Enum: NOUN, PRONOUN, ADVERB, etc.
    public bool IsCompleted { get; set; }
    public List<Guid> SynonymIds { get; set; }
    public List<Guid> AntonymIds { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Grammar Grammar { get; set; }
    public Usage Usage { get; set; }
}

