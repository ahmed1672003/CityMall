namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetUnDeletedUserByIdSpecification : Specification<User>
{
    public AsNoTrackingGetUnDeletedUserByIdSpecification(string id)
        : base(u => u.Id.Equals(id))
    {
        StopTracking();
    }
}
