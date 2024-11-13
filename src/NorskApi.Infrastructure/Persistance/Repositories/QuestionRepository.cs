using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.QuestionAggregate;
using NorskApi.Domain.QuestionAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder;

    public QuestionRepository(
        NorskApiDbContext dbContext,
        IQueryParamsWithEssayBuilder queryParamsWithEssayBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsWithEssayBuilder = queryParamsWithEssayBuilder;
    }

    public async Task<List<Question>> GetAll(
        QueryParamsWithEssayFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query =
            filters != null
                ? queryParamsWithEssayBuilder.BuildQueriesQuestions<Question>(filters)
                : null;
        if (query == null)
        {
            return await this.dbContext.Questions.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<Question?> GetById(QuestionId questionId, CancellationToken cancellationToken)
    {
        return await this.dbContext.Questions.SingleOrDefaultAsync(
            x => x.Id == questionId,
            cancellationToken
        );
    }

    public async Task Add(Question question, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(question, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Question question, CancellationToken cancellationToken)
    {
        this.dbContext.Update(question);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Question question, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(question);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
