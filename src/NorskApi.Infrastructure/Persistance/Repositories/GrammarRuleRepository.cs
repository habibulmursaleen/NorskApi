using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class GrammarRuleRepository : IGrammarRuleRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsWithTopicBuilder queryParamsWithTopicBuilder;

    public GrammarRuleRepository(
        NorskApiDbContext dbContext,
        IQueryParamsWithTopicBuilder queryParamsWithTopicBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsWithTopicBuilder = queryParamsWithTopicBuilder;
    }

    public async Task<List<GrammarRule>> GetAll(
        QueryParamsWithTopicFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query = dbContext.GrammarRules.AsQueryable();
        query =
            filters != null
                ? queryParamsWithTopicBuilder.BuildQueriesGrammarRules<GrammarRule>(filters)
                : query;
        if (query == null)
        {
            return await this.dbContext.GrammarRules.ToListAsync(
                cancellationToken: cancellationToken
            );
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<List<GrammarRule>> GetAllByTopicId(
        TopicId topicId,
        QueryParamsWithTopicFilters filters,
        CancellationToken cancellationToken
    )
    {
        var query = queryParamsWithTopicBuilder.BuildQueriesGrammarRules<GrammarRule>(filters);
        query = query?.Where(x => x.TopicId == topicId);
        if (query == null)
        {
            return new List<GrammarRule>();
        }
        List<GrammarRule>? grammarRules = await query.AsSplitQuery().ToListAsync(cancellationToken);

        return grammarRules;
    }

    public async Task<GrammarRule?> GetById(
        TopicId topicId,
        GrammarRuleId grammarRuleId,
        CancellationToken cancellationToken
    )
    {
        return await this.dbContext.GrammarRules.SingleOrDefaultAsync(
            x => x.TopicId == topicId && x.Id == grammarRuleId,
            cancellationToken
        );
    }

    public async Task Add(GrammarRule grammarRule, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(grammarRule, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(GrammarRule grammarRule, CancellationToken cancellationToken)
    {
        this.dbContext.Update(grammarRule);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(GrammarRule grammarRule, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(grammarRule);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
