using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Filters;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParams;
using NorskApi.Domain.Common.Enums;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Common;

public class QueryParamsBuilder : IQueryParamsBuilder
{
    private readonly NorskApiDbContext dbContext;

    public QueryParamsBuilder(NorskApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /* private IQueryable<T> ApplySorting<T>(IQueryable<T> source, string sortBy, bool descending)
    {
        // Expression in C# lets you dynamically create and manipulate code expressions, enabling flexible, runtime-generated queries, filters, or sorting based on user input.
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, sortBy);
        var lambda = Expression.Lambda(property, parameter);

        string methodName = descending ? "OrderByDescending" : "OrderBy";
        var methodCallExpression = Expression.Call(
            typeof(Queryable),
            methodName,
            new Type[] { source.ElementType, property.Type },
            source.Expression,
            Expression.Quote(lambda)
        );

        return source.Provider.CreateQuery<T>(methodCallExpression);
    } */

    public IQueryable<T>? BuildQueries<T>(GetAllDiscussionsFiltersQuery filters)
    {
        var query = dbContext.Discussions.AsQueryable();
        double skip =
            (filters.Page > 0 && filters.Size > 0) ? (filters.Page - 1) * (int)filters.Size : 0;
        double take = filters.Size > 0 ? (int)filters.Size : (int)filters.Count;

        if (
            filters.DifficultyLevel != default
            || filters.DifficultyLevel != DifficultyLevel.ALL
                && Enum.IsDefined(typeof(DifficultyLevel), filters.DifficultyLevel)
        )
        {
            query = query.Where(x => x.DifficultyLevel == filters.DifficultyLevel);
        }
        if (filters.FromDate != default)
        {
            query = query.Where(x => x.CreatedDateTime >= filters.FromDate);
        }
        if (filters.ToDate != default)
        {
            query = query.Where(x => x.CreatedDateTime <= filters.ToDate);
        }
        if (filters.Count > 0)
        {
            query = query.Take((int)filters.Count);
        }
        if (filters.Skip > 0)
        {
            query = query.Skip((int)filters.Skip);
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
