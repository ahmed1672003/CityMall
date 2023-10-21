namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingCheckDuplicatedUserByUserNameSpecification :
     Specification<User>
{
    public AsNoTrackingCheckDuplicatedUserByUserNameSpecification(string id, string userName)
        : base(u => u.UserName.Equals(userName) && !u.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
