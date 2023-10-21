namespace CityMall.Specifications.Specifications.Users;
public sealed class AsTrackingGetUnDeletedUserByEmailSpecification : Specification<User>
{
    public AsTrackingGetUnDeletedUserByEmailSpecification(string email)
        : base(u => u.Email.Equals(email))
    {
        StopTracking();
    }
}
