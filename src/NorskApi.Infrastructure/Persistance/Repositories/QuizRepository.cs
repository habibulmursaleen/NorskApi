using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.QuizAggregate;
using NorskApi.Domain.QuizAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQuizQueryParamsBuilder quizQueryParamsBuilder;

    public QuizRepository(
        NorskApiDbContext dbContext,
        IQuizQueryParamsBuilder quizQueryParamsBuilder
    )
    {
        this.dbContext = dbContext;
        this.quizQueryParamsBuilder = quizQueryParamsBuilder;
    }

    public async Task<List<Quiz>> GetAll(
        QuizQueryParamsFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query = dbContext.Quizes.AsQueryable();
        query = filters != null ? quizQueryParamsBuilder.BuildQueriesQuizes<Quiz>(filters) : query;
        if (query == null)
        {
            return await this.dbContext.Quizes.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<Quiz?> GetById(QuizId quizId, CancellationToken cancellationToken)
    {
        return await this.dbContext.Quizes.SingleOrDefaultAsync(
            x => x.Id == quizId,
            cancellationToken
        );
    }

    public async Task Add(Quiz quiz, CancellationToken cancellationToken)
    {
        await this.dbContext.AddAsync(quiz, cancellationToken);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Quiz quiz, CancellationToken cancellationToken)
    {
        this.dbContext.Update(quiz);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Quiz quiz, CancellationToken cancellationToken)
    {
        this.dbContext.Remove(quiz);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
