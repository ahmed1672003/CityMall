namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetUserByEmailSpecification : Specification<User>
{
    public AsNoTrackingGetUserByEmailSpecification(string email) : base(u => u.Email.Equals(email))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
