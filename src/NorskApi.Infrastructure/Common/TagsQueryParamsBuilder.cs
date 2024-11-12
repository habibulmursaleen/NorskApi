using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Filters;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Persistance.IQueryParamsBuilders;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.TagAggregate.Enums;
using NorskApi.Infrastructure.Persistance.DBContext;

namespace NorskApi.Infrastructure.Common;

public class TagsQueryParamsBuilder : ITagsQueryParamsBuilder
{
    private readonly NorskApiDbContext dbContext;

    public TagsQueryParamsBuilder(NorskApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<T>? BuildQueriesTags<T>(TagsQueryParamsFilters filters)
    {
        var query = dbContext.Tags.AsQueryable();

        if (
            filters.TagType != default
            || filters.TagType != TagType.ESSAY && Enum.IsDefined(typeof(TagType), filters.TagType)
        )
        {
            query = query.Where(x => x.TagType == filters.TagType);
        }

        return (IQueryable<T>?)query;
    }
}
