namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingCheckUnDeletedDuplicatedUserByUserNameSpecification : Specification<User>
{
    public AsNoTrackingCheckUnDeletedDuplicatedUserByUserNameSpecification(string id, string userName)
        : base(u => u.UserName.Equals(userName) && !u.Id.Equals(id))
    {
        StopTracking();
    }
}
