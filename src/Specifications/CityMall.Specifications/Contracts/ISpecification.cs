﻿namespace CityMall.Specifications.Contracts;
public interface ISpecification<TEntity> where TEntity : class
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    List<Expression<Func<TEntity, object>>> Includes { get; }
    Expression<Func<TEntity, object>> OrderBy { get; }
    Expression<Func<TEntity, object>> OrderByDescending { get; }
    Expression<Func<TEntity, object>> GroupBy { get; }
    object ExecuteUpdateValue { get; }
    List<string> IncludesString { get; }
    (int pageNumber, int pageSize) PaginationRequirments { get; }
    bool IsSplitQuery { get; }
    bool IsPagingEnabled { get; }
    bool IsTrackingOf { get; }
    bool IsTrackingWithIdentityResolutionOf { get; }
    bool IsQueryFilterIgnored { get; }
}