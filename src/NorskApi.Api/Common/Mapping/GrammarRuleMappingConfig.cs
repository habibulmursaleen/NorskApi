namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.GrammarRules.Command.CreateGrammarRule;
using NorskApi.Application.GrammarRules.Command.DeleteGrammarRule;
using NorskApi.Application.GrammarRules.Command.UpdateGrammarRule;
using NorskApi.Application.GrammarRules.Queries.GetAllGrammarRules;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.GrammarRules.Requests.Create;
using NorskApi.Contracts.GrammarRules.Requests.Update;

public class GrammarRuleMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<(Guid topicId, CreateGrammarRuleRequest request), CreateGrammarRuleCommand>()
            .Map(dest => dest.TopicId, src => src.topicId)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Description, src => src.request.Description)
            .Map(dest => dest.ExplanatoryNotes, src => src.request.ExplanatoryNotes)
            .Map(dest => dest.SentenceStructures, src => src.request.SentenceStructures)
            .Map(dest => dest.RuleType, src => src.request.RuleType)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel)
            .Map(dest => dest.GrammarRuleTagIds, src => src.request.GrammarRuleTagIds)
            .Map(dest => dest.AdditionalInformation, src => src.request.AdditionalInformation)
            .Map(dest => dest.Comments, src => src.request.Comments)
            .Map(dest => dest.RelatedGrammarRuleIds, src => src.request.RelatedGrammarRuleIds)
            .Map(dest => dest.Exceptions, src => src.request.Exceptions)
            .Map(dest => dest.ExampleOfRules, src => src.request.ExampleOfRules);

        config
            .NewConfig<
                (Guid topicId, Guid id, UpdateGrammarRuleRequest request),
                UpdateGrammarRuleCommand
            >()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.TopicId, src => src.topicId)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Description, src => src.request.Description)
            .Map(dest => dest.ExplanatoryNotes, src => src.request.ExplanatoryNotes)
            .Map(dest => dest.SentenceStructures, src => src.request.SentenceStructures)
            .Map(dest => dest.RuleType, src => src.request.RuleType)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel)
            .Map(dest => dest.GrammarRuleTagIds, src => src.request.GrammarRuleTagIds)
            .Map(dest => dest.AdditionalInformation, src => src.request.AdditionalInformation)
            .Map(dest => dest.Comments, src => src.request.Comments)
            .Map(dest => dest.RelatedGrammarRuleIds, src => src.request.RelatedGrammarRuleIds)
            .Map(dest => dest.Exceptions, src => src.request.Exceptions)
            .Map(dest => dest.ExampleOfRules, src => src.request.ExampleOfRules);

        config.NewConfig<Guid, DeleteGrammarRuleCommand>().Map(dest => dest.Id, src => src);

        // Map Filter Request to Filter Query
        config
            .NewConfig<
                (Guid topicId, QueryParamsBaseFiltersRequest filters),
                GetAllGrammarRulesQuery
            >()
            .Map(dest => dest.TopicId, src => src.topicId)
            .Map(dest => dest.Filters, src => src);

        config
            .NewConfig<QueryParamsBaseFiltersRequest, QueryParamsBaseFilters>()
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<CreateExceptionRequest, CreateExceptionCommand>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Comments, src => src.Comments)
            .Map(dest => dest.CorrectSentence, src => src.CorrectSentence)
            .Map(dest => dest.IncorrectSentence, src => src.IncorrectSentence);

        config
            .NewConfig<CreateSentenceStructureRequest, CreateSentenceStructureCommand>()
            .Map(dest => dest.Label, src => src.Label);

        config
            .NewConfig<UpdateSentenceStructureRequest, UpdateSentenceStructureCommand>()
            .Map(dest => dest.Label, src => src.Label);

        config
            .NewConfig<UpdateExceptionRequest, UpdateExceptionCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.GrammarRuleId, src => src.GrammarRuleId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Comments, src => src.Comments)
            .Map(dest => dest.CorrectSentence, src => src.CorrectSentence)
            .Map(dest => dest.IncorrectSentence, src => src.IncorrectSentence);

        config
            .NewConfig<CreateExampleOfRuleRequest, CreateExampleOfRuleCommand>()
            .Map(dest => dest.Subjunction, src => src.Subjunction)
            .Map(dest => dest.Subject, src => src.Subject)
            .Map(dest => dest.Adverbial, src => src.Adverbial)
            .Map(dest => dest.Verb, src => src.Verb)
            .Map(dest => dest.Object, src => src.Object)
            .Map(dest => dest.Rest, src => src.Rest)
            .Map(dest => dest.CorrectSentence, src => src.CorrectSentence)
            .Map(dest => dest.EnglishSentence, src => src.EnglishSentence)
            .Map(dest => dest.IncorrectSentence, src => src.IncorrectSentence)
            .Map(dest => dest.TransformationFrom, src => src.TransformationFrom)
            .Map(dest => dest.TransformationTo, src => src.TransformationTo);

        config
            .NewConfig<UpdateExampleOfRuleRequest, UpdateExampleOfRuleCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.GrammarRuleId, src => src.GrammarRuleId)
            .Map(dest => dest.Subjunction, src => src.Subjunction)
            .Map(dest => dest.Subject, src => src.Subject)
            .Map(dest => dest.Adverbial, src => src.Adverbial)
            .Map(dest => dest.Verb, src => src.Verb)
            .Map(dest => dest.Object, src => src.Object)
            .Map(dest => dest.Rest, src => src.Rest)
            .Map(dest => dest.CorrectSentence, src => src.CorrectSentence)
            .Map(dest => dest.EnglishSentence, src => src.EnglishSentence)
            .Map(dest => dest.IncorrectSentence, src => src.IncorrectSentence)
            .Map(dest => dest.TransformationFrom, src => src.TransformationFrom)
            .Map(dest => dest.TransformationTo, src => src.TransformationTo);
    }
}
