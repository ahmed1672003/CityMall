namespace CityMall.Specifications.Specifications.Users;

public sealed class AsTrackingGetUnDeletedUserByIdSpecification : Specification<User>
{
    public AsTrackingGetUnDeletedUserByIdSpecification(string id)
        : base(u => u.Id.Equals(id))
    {
    }
}
