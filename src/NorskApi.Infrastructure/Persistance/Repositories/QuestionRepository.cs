using Microsoft.EntityFrameworkCore;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate;
using NorskApi.Domain.QuestionAggregate.ValueObjects;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Persistance.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly NorskApiDbContext dbContext;
    private readonly IQueryParamsBaseBuilder queryParamsBaseBuilder;

    public QuestionRepository(
        NorskApiDbContext dbContext,
        IQueryParamsBaseBuilder queryParamsBaseBuilder
    )
    {
        this.dbContext = dbContext;
        this.queryParamsBaseBuilder = queryParamsBaseBuilder;
    }

    public async Task<List<Question>> GetAll(
        QueryParamsBaseFilters? filters,
        CancellationToken cancellationToken
    )
    {
        var query =
            filters != null
                ? queryParamsBaseBuilder.BuildQueriesQuestions<Question>(filters)
                : null;
        if (query == null)
        {
            return await this.dbContext.Questions.ToListAsync();
        }
        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }

    public async Task<List<Question>> GetAllByEssayId(
        EssayId essayId,
        QueryParamsBaseFilters filters,
        CancellationToken cancellationToken
    )
    {
        var query = queryParamsBaseBuilder.BuildQueriesQuestions<Question>(filters);
        query = query?.Where(x => x.EssayId == essayId);
        if (query == null)
        {
            return new List<Question>();
        }
        List<Question>? questions = await query.AsSplitQuery().ToListAsync(cancellationToken);

        return questions;
    }

    public async Task<Question?> GetById(
        EssayId essayId,
        QuestionId questionId,
        CancellationToken cancellationToken
    )
    {
        return await this.dbContext.Questions.SingleOrDefaultAsync(
            x => x.EssayId == essayId && x.Id == questionId,
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
