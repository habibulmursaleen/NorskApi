using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;
using NorskApi.Domain.WordAggregate;
using NorskApi.Domain.WordAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class WordRepository : IWordRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder;

    public WordRepository(
        NorskApiDbContext dbContext,
        IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsWithEssayBuilder = queryParamsWithEssayBuilder;
    }

    public async Task<List<Word>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query = dbContext.Words.AsQueryable();
        query =
            filters != null ? queryParamsWithEssayBuilder.BuildQueriesWords<Word>(filters) : query;
        if (query == null)
        {
            return await this.dbContext.Words.ToListAsync(cancellationToken: cancellationToken);
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<Word?> GetById(WordId wordId, CancellationToken cancellationToken)
    {
        return await this.dbContext.Words.SingleOrDefaultAsync(
            x => x.Id == wordId,
            cancellationToken
        );
    }

    public async Task Add(Word word, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(word, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Word word, CancellationToken cancellationToken)
    {
        this.dbContext.Update(word);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Word word, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(word);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
