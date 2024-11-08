using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate.Entites;
using NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.GrammarRule;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;
using Exception = NorskApi.Domain.GrammmarRuleAggregate.Entites.Exception;

namespace NorskApi.Domain.GrammmarRuleAggregate;

public sealed class GrammarRule : AggregateRoot<GrammarRuleId, Guid>
{
    public TopicId TopicId { get; set; }
    public string Label { get; set; }
    public string? Description { get; set; }
    public string? ExplanatoryNotes { get; set; }
    public List<string>? SentenceStructure { get; set; }
    public string? RuleType { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, etc.
    public List<string>? Tags { get; set; }
    public string? AdditionalInformation { get; set; }
    public List<string>? Comments { get; set; }
    public List<Guid>? RelatedRuleIds { get; set; }

    public List<Guid> GetRuleIds() => RelatedRuleIds?.ToList() ?? new List<Guid>();

    public List<Exception> exceptions = new();
    public List<ExampleOfRule> exampleOfRules = new();
    public IReadOnlyCollection<Exception> Exceptions => this.exceptions;
    public IReadOnlyCollection<ExampleOfRule> ExampleOfRules => this.exampleOfRules;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private GrammarRule() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private GrammarRule(
        GrammarRuleId id,
        TopicId topicId,
        string label,
        string? description,
        string? explanatoryNotes,
        string? ruleType,
        string? additionalInformation,
        DifficultyLevel difficultyLevel,
        List<string>? sentenceStructure,
        List<string>? tags,
        List<string>? comments,
        List<GrammarRuleId>? relatedRuleIds,
        List<Exception> exceptions,
        List<ExampleOfRule> exampleOfRules
    )
        : base(id)
    {
        this.Id = id;
        this.TopicId = topicId;
        this.Label = label;
        this.Description = description;
        this.ExplanatoryNotes = explanatoryNotes;
        this.RuleType = ruleType;
        this.AdditionalInformation = additionalInformation;
        this.DifficultyLevel = difficultyLevel;
        this.SentenceStructure = sentenceStructure;
        this.Tags = tags;
        this.Comments = comments;
        this.RelatedRuleIds = relatedRuleIds?.Select(t => t.Value).ToList();
        this.exceptions = exceptions;
        this.exampleOfRules = exampleOfRules;
    }

    public static GrammarRule Create(
        TopicId topicId,
        string label,
        string? description,
        string? explanatoryNotes,
        List<string>? sentenceStructure,
        string? ruleType,
        DifficultyLevel difficultyLevel,
        List<string>? tags,
        string? additionalInformation,
        List<string>? comments,
        List<GrammarRuleId>? relatedRuleIds,
        List<Exception> exceptions,
        List<ExampleOfRule> exampleOfRules
    )
    {
        GrammarRule grammarRule = new GrammarRule(
            GrammarRuleId.CreateUnique(),
            topicId,
            label,
            description,
            explanatoryNotes,
            ruleType,
            additionalInformation,
            difficultyLevel,
            sentenceStructure,
            tags,
            comments,
            relatedRuleIds,
            exceptions,
            exampleOfRules
        );

        grammarRule.AddDomainEvent(new GrammarRuleCreatedDomainEvent(grammarRule));

        return grammarRule;
    }

    public void Update(
        TopicId topicId,
        string label,
        string? description,
        string? explanatoryNotes,
        List<string>? sentenceStructure,
        string? ruleType,
        DifficultyLevel difficultyLevel,
        List<string>? tags,
        string? additionalInformation,
        List<string>? comments,
        List<GrammarRuleId>? relatedRuleIds,
        List<Exception> exceptions,
        List<ExampleOfRule> exampleOfRules
    )
    {
        this.TopicId = topicId;
        this.Label = label;
        this.Description = description;
        this.ExplanatoryNotes = explanatoryNotes;
        this.RuleType = ruleType;
        this.AdditionalInformation = additionalInformation;
        this.DifficultyLevel = difficultyLevel;
        this.SentenceStructure = sentenceStructure;
        this.Tags = tags;
        this.Comments = comments;
        this.RelatedRuleIds = relatedRuleIds?.Select(t => t.Value).ToList();

        UpdateExceptions(exceptions);
        UpdateExampleOfRules(exampleOfRules);

        this.AddDomainEvent(new GrammarRuleUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new GrammarRuleDeletedDomainEvent(this));
    }

    private void UpdateExceptions(List<Exception> newExceptions)
    {
        if (newExceptions is not null)
        {
            // Update existing exceptions or add new ones
            foreach (var newException in newExceptions)
            {
                var existingException = this.exceptions?.FirstOrDefault(e =>
                    e.Id == newException.Id
                );
                if (existingException is not null)
                {
                    // Update existing exception
                    existingException.Update(
                        newException.GrammarRuleId_FK,
                        newException.Title,
                        newException.Description,
                        newException.Comments,
                        newException.CorrectSentence,
                        newException.IncorrectSentence
                    );
                }
                else
                {
                    // Add new exception
                    this.exceptions?.Add(newException);
                }
            }

            // Remove exceptions that are no longer in the new list
            if (this.exceptions != null)
            {
                this.exceptions.RemoveAll(e => newExceptions.All(ne => ne.Id != e.Id));
            }
        }
    }

    private void UpdateExampleOfRules(List<ExampleOfRule> newExampleOfRules)
    {
        if (newExampleOfRules is not null)
        {
            // Update existing exampleOfRules or add new ones
            foreach (var newExampleOfRule in newExampleOfRules)
            {
                var existingExampleOfRule = this.exampleOfRules?.FirstOrDefault(e =>
                    e.Id == newExampleOfRule.Id
                );
                if (existingExampleOfRule is not null)
                {
                    // Update existing exampleOfRule
                    existingExampleOfRule.Update(
                        newExampleOfRule.GrammarRuleId_FK,
                        newExampleOfRule.Subjunction,
                        newExampleOfRule.Subject,
                        newExampleOfRule.Adverbial,
                        newExampleOfRule.Verb,
                        newExampleOfRule.Object,
                        newExampleOfRule.Rest,
                        newExampleOfRule.CorrectSentence,
                        newExampleOfRule.EnglishSentence,
                        newExampleOfRule.IncorrectSentence,
                        newExampleOfRule.TransformationFrom,
                        newExampleOfRule.TransformationTo
                    );
                }
                else
                {
                    // Add new exampleOfRule
                    this.exampleOfRules?.Add(newExampleOfRule);
                }
            }

            // Remove exampleOfRules that are no longer in the new list
            if (this.exampleOfRules != null)
            {
                this.exampleOfRules.RemoveAll(e => newExampleOfRules.All(ne => ne.Id != e.Id));
            }
        }
    }

    public void AddExceptions(List<Exception> exceptions)
    {
        if (exceptions is not null)
        {
            this.exceptions.AddRange(exceptions);
        }
    }

    public void AddExampleOfRules(List<ExampleOfRule> exampleOfRules)
    {
        if (exampleOfRules is not null)
        {
            this.exampleOfRules.AddRange(exampleOfRules);
        }
    }
}
