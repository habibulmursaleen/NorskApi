using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.GrammarTopicAggregate;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class GrammarTopicRepository : IGrammarTopicRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsBaseBuilder queryParamsBaseBuilder;

    public GrammarTopicRepository(
        NorskApiDbContext dbContext,
        IQueryParamsBaseBuilder queryParamsBaseBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsBaseBuilder = queryParamsBaseBuilder;
    }

    public async Task<List<GrammarTopic>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query =
            filters != null
                ? queryParamsBaseBuilder.BuildQueriesGrammarTopics<GrammarTopic>(filters)
                : null;
        if (query == null)
        {
            return await this.dbContext.GrammarTopics.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<GrammarTopic?> GetById(TopicId topicId, CancellationToken cancellationToken)
    {
        return await this.dbContext.GrammarTopics.SingleOrDefaultAsync(
            x => x.Id == topicId,
            cancellationToken
        );
    }

    public async Task Add(GrammarTopic grammarTopic, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(grammarTopic, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(GrammarTopic grammarTopic, CancellationToken cancellationToken)
    {
        this.dbContext.Update(grammarTopic);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(GrammarTopic grammarTopic, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(grammarTopic);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
