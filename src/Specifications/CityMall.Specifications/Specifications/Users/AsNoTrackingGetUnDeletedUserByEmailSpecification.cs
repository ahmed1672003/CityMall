namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetUnDeletedUserByEmailSpecification : Specification<User>
{
    public AsNoTrackingGetUnDeletedUserByEmailSpecification(string email)
        : base(u => u.Email.Equals(email))
    {
        StopTracking();

    }
}
