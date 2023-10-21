namespace CityMall.Specifications.Specifications.Users;
public sealed class AsTrackingGetDeletedUserByIdSpecification : Specification<User>
{
    public AsTrackingGetDeletedUserByIdSpecification(string id)
        : base(u => u.IsDeleted && u.Id.Equals(id))
    {
        IgnorQueryFilter();
    }
}