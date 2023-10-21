namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingCheckUnDeletedDuplicatedUserByEmailSpecification : Specification<User>
{
    public AsNoTrackingCheckUnDeletedDuplicatedUserByEmailSpecification(string id, string email)
        : base(u => u.Email.Equals(email) && !u.Id.Equals(id))
    {
        StopTracking();
    }
}
