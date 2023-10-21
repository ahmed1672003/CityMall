namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingCheckDuplicatedUserByEmailSpecification : Specification<User>
{
    public AsNoTrackingCheckDuplicatedUserByEmailSpecification(string id, string email)
         : base(u => u.Email.Equals(email) && !u.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
