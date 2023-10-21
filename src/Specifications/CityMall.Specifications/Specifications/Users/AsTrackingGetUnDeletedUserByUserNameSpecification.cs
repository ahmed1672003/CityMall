namespace CityMall.Specifications.Specifications.Users;
public sealed class AsTrackingGetUnDeletedUserByUserNameSpecification : Specification<User>
{
    public AsTrackingGetUnDeletedUserByUserNameSpecification(string userName)
        : base(u => u.UserName.Equals(userName))
    {

    }
}
