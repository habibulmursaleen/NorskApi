namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Words.Command.CreateWord;
using NorskApi.Application.Words.Command.DeleteWord;
using NorskApi.Application.Words.Command.UpdateWord;
using NorskApi.Application.Words.Models;
using NorskApi.Application.Words.Queries.GetAllWords;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Words.Requests.Create;
using NorskApi.Contracts.Words.Requests.Update;
using NorskApi.Contracts.Words.Response;
using NorskApi.Domain.WordAggregate;

public class WordMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateWordRequest, CreateWordCommand>()
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Meaning, src => src.Meaning)
            .Map(dest => dest.EnTranslation, src => src.EnTranslation)
            .Map(dest => dest.NativeMeaning, src => src.NativeMeaning)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.PartOfSpeechTag, src => src.PartOfSpeechTag)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.WordSynonymIds, src => src.WordSynonymIds)
            .Map(dest => dest.WordAntonymIds, src => src.WordAntonymIds)
            .Map(dest => dest.WordGrammer, src => src.WordGrammer)
            .Map(dest => dest.WordUsageExample, src => src.WordUsageExample);

        config
            .NewConfig<(Guid id, UpdateWordRequest request), UpdateWordCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.EssayId, src => src.request.EssayId)
            .Map(dest => dest.Title, src => src.request.Title)
            .Map(dest => dest.Meaning, src => src.request.Meaning)
            .Map(dest => dest.EnTranslation, src => src.request.EnTranslation)
            .Map(dest => dest.NativeMeaning, src => src.request.NativeMeaning)
            .Map(dest => dest.Type, src => src.request.Type)
            .Map(dest => dest.PartOfSpeechTag, src => src.request.PartOfSpeechTag)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.WordSynonymIds, src => src.request.WordSynonymIds)
            .Map(dest => dest.WordAntonymIds, src => src.request.WordAntonymIds)
            .Map(dest => dest.WordUsageExample, src => src.request.WordUsageExample)
            .Map(dest => dest.WordGrammer, src => src.request.WordGrammer);

        config.NewConfig<Guid, DeleteWordCommand>().Map(dest => dest.Id, src => src);

        // Map Filter Request to Filter Query
        config
            .NewConfig<QueryParamsWithEssayFiltersRequest, GetAllWordsQuery>()
            .Map(dest => dest.Filters, src => src);

        config
            .NewConfig<QueryParamsBaseFiltersRequest, QueryParamsBaseFilters>()
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<CreateWordGrammerRequest, CreateWordGrammerCommand>()
            .Map(dest => dest.GenderMasculine, src => src.GenderMasculine)
            .Map(dest => dest.GenderFeminine, src => src.GenderFeminine)
            .Map(dest => dest.GenderNeutral, src => src.GenderNeutral)
            .Map(dest => dest.SingularDefinitiv, src => src.SingularDefinitiv)
            .Map(dest => dest.SingularIndefinitiv, src => src.SingularIndefinitiv)
            .Map(dest => dest.PluralDefinitiv, src => src.PluralDefinitiv)
            .Map(dest => dest.PluralIndefinitiv, src => src.PluralIndefinitiv)
            .Map(dest => dest.Infinitiv, src => src.Infinitiv)
            .Map(dest => dest.PresentTense, src => src.PresentTense)
            .Map(dest => dest.PastTense, src => src.PastTense)
            .Map(dest => dest.PresentPerfectTense, src => src.PresentPerfectTense)
            .Map(dest => dest.FutureTense, src => src.FutureTense)
            .Map(dest => dest.Positive, src => src.Positive)
            .Map(dest => dest.Comparative, src => src.Comparative)
            .Map(dest => dest.Superlative, src => src.Superlative)
            .Map(dest => dest.SuperlativeDetermined, src => src.SuperlativeDetermined)
            .Map(dest => dest.PastParticiple, src => src.PastParticiple)
            .Map(dest => dest.PresentParticiple, src => src.PresentParticiple)
            .Map(dest => dest.Irregular, src => src.Irregular)
            .Map(dest => dest.StrongVerb, src => src.StrongVerb)
            .Map(dest => dest.WeakVerb, src => src.WeakVerb);

        config
            .NewConfig<CreateWordUsageExampleRequest, CreateWordUsageExampleCommand>()
            .Map(dest => dest.CorrectSentence, src => src.CorrectSentence)
            .Map(dest => dest.IncorrectSentence, src => src.IncorrectSentence)
            .Map(dest => dest.EnglishSentence, src => src.EnglishSentence)
            .Map(dest => dest.NewSentence, src => src.NewSentence);

        config
            .NewConfig<UpdateWordUsageExampleRequest, UpdateWordUsageExampleCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.WordId, src => src.WordId)
            .Map(dest => dest.CorrectSentence, src => src.CorrectSentence)
            .Map(dest => dest.IncorrectSentence, src => src.IncorrectSentence)
            .Map(dest => dest.EnglishSentence, src => src.EnglishSentence)
            .Map(dest => dest.NewSentence, src => src.NewSentence);

        config
            .NewConfig<UpdateWordGrammerRequest, UpdateWordGrammerCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.WordId, src => src.WordId)
            .Map(dest => dest.GenderMasculine, src => src.GenderMasculine)
            .Map(dest => dest.GenderFeminine, src => src.GenderFeminine)
            .Map(dest => dest.GenderNeutral, src => src.GenderNeutral)
            .Map(dest => dest.SingularDefinitiv, src => src.SingularDefinitiv)
            .Map(dest => dest.SingularIndefinitiv, src => src.SingularIndefinitiv)
            .Map(dest => dest.PluralDefinitiv, src => src.PluralDefinitiv)
            .Map(dest => dest.PluralIndefinitiv, src => src.PluralIndefinitiv)
            .Map(dest => dest.Infinitiv, src => src.Infinitiv)
            .Map(dest => dest.PresentTense, src => src.PresentTense)
            .Map(dest => dest.PastTense, src => src.PastTense)
            .Map(dest => dest.PresentPerfectTense, src => src.PresentPerfectTense)
            .Map(dest => dest.FutureTense, src => src.FutureTense)
            .Map(dest => dest.Positive, src => src.Positive)
            .Map(dest => dest.Comparative, src => src.Comparative)
            .Map(dest => dest.Superlative, src => src.Superlative)
            .Map(dest => dest.SuperlativeDetermined, src => src.SuperlativeDetermined)
            .Map(dest => dest.PastParticiple, src => src.PastParticiple)
            .Map(dest => dest.PresentParticiple, src => src.PresentParticiple)
            .Map(dest => dest.Irregular, src => src.Irregular)
            .Map(dest => dest.StrongVerb, src => src.StrongVerb)
            .Map(dest => dest.WeakVerb, src => src.WeakVerb);

        config
            .NewConfig<WordResult, WordResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Meaning, src => src.Meaning)
            .Map(dest => dest.EnTranslation, src => src.EnTranslation)
            .Map(dest => dest.NativeMeaning, src => src.NativeMeaning)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.PartOfSpeechTag, src => src.PartOfSpeechTag)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.WordSynonymeIds, src => src.WordSynonymeIds)
            .Map(dest => dest.WordAntonymeIds, src => src.WordAntonymeIds)
            .Map(dest => dest.WordGrammer, src => src.WordGrammer)
            .Map(dest => dest.WordUsageExample, src => src.WordUsageExample)
            .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime);
    }
}
