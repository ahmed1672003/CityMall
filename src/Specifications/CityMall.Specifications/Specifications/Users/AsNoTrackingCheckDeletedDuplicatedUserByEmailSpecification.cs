namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingCheckDeletedDuplicatedUserByEmailSpecification : Specification<User>
{
    public AsNoTrackingCheckDeletedDuplicatedUserByEmailSpecification(string id, string email)
        : base(u => u.IsDeleted && u.Email.Equals(email) && !u.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
