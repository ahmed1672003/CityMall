namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingCheckDeletedDuplicatedUserByUserNameSpecification : Specification<User>
{
    public AsNoTrackingCheckDeletedDuplicatedUserByUserNameSpecification(string id, string userName)
        : base(u => u.IsDeleted && u.UserName.Equals(userName) && !u.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
