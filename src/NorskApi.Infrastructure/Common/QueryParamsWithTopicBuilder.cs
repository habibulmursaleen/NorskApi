using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.Common.Enums;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Common;

public class QueryParamsWithTopicBuilder : IQueryParamsWithTopicBuilder
{
    private readonly NorskApiDbContext dbContext;

    public QueryParamsWithTopicBuilder(NorskApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<T>? BuildQueriesTaskWorks<T>(QueryParamsWithTopicFilters filters)
    {
        var query = dbContext.TaskWorks.AsQueryable();
        double skip =
            (filters.Page > 0 && filters.Size > 0) ? (filters.Page - 1) * (int)filters.Size : 0;
        double take = filters.Size > 0 ? (int)filters.Size : 25;

        if (
            filters.DifficultyLevel != default
            || filters.DifficultyLevel != DifficultyLevel.ALL
                && Enum.IsDefined(typeof(DifficultyLevel), filters.DifficultyLevel)
        )
        {
            query = query.Where(x => x.DifficultyLevel == filters.DifficultyLevel);
        }
        if (filters.TopicId != default)
        {
            query = query.Where(x => x.TopicId == filters.TopicId);
        }
        if (!string.IsNullOrEmpty(filters.SortBy))
        {
            switch (filters.SortBy.ToLower())
            {
                case "asc":
                    query = query.OrderBy(x => x.CreatedDateTime);
                    break;
                case "desc":
                    query = query.OrderByDescending(x => x.CreatedDateTime);
                    break;
                default:
                    query = query.OrderBy(x => x.CreatedDateTime);
                    break;
            }
        }

        return (IQueryable<T>?)query;
    }

    public IQueryable<T>? BuildQueriesGrammarRules<T>(QueryParamsWithTopicFilters filters)
    {
        var query = dbContext.GrammarRules.AsQueryable();
        double skip =
            (filters.Page > 0 && filters.Size > 0) ? (filters.Page - 1) * (int)filters.Size : 0;
        double take = filters.Size > 0 ? (int)filters.Size : 25;

        if (
            filters.DifficultyLevel != default
            || filters.DifficultyLevel != DifficultyLevel.ALL
                && Enum.IsDefined(typeof(DifficultyLevel), filters.DifficultyLevel)
        )
        {
            query = query.Where(x => x.DifficultyLevel == filters.DifficultyLevel);
        }
        if (filters.TopicId != default)
        {
            query = query.Where(x => x.TopicId == filters.TopicId);
        }
        if (!string.IsNullOrEmpty(filters.SortBy))
        {
            switch (filters.SortBy.ToLower())
            {
                case "asc":
                    query = query.OrderBy(x => x.CreatedDateTime);
                    break;
                case "desc":
                    query = query.OrderByDescending(x => x.CreatedDateTime);
                    break;
                default:
                    query = query.OrderBy(x => x.CreatedDateTime);
                    break;
            }
        }

        return (IQueryable<T>?)query;
    }
}
