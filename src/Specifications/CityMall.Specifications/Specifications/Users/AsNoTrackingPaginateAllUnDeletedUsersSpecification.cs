﻿namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingPaginateAllUnDeletedUsersSpecification : Specification<User>
{
    public AsNoTrackingPaginateAllUnDeletedUsersSpecification(int pageNumber = 1, int pageSize = 10, string keyWords = "", Expression<Func<User, object>> orderBy = null)
        : base
        (
        u => (
             u.Id.Contains(keyWords) ||
             u.UserName.Contains(keyWords) ||
             u.Email.Contains(keyWords) ||
             u.FirstName.Contains(keyWords) ||
             u.LastName.Contains(keyWords))
        )

    {
        AsSplitQuery(true);
        StopTracking();
        ApplyPaging((pageNumber, pageSize));
        AddOrderBy(orderBy);
    }
}
