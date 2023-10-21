namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetUnDeletedUserByUserNameSpecification : Specification<User>
{
    public AsNoTrackingGetUnDeletedUserByUserNameSpecification(string userName)
         : base(u => u.UserName.Equals(userName))
    {
        StopTracking();
    }
}
