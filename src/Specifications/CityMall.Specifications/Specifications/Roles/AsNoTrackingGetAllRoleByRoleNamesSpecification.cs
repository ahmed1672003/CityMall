namespace CityMall.Specifications.Specifications.Roles;
public sealed class AsNoTrackingGetAllRoleByRoleNamesSpecification : Specification<Role>
{
    public AsNoTrackingGetAllRoleByRoleNamesSpecification(IList<string> roleNames)
        : base(r => roleNames.Contains(r.Name))
    {
        StopTracking();
    }
}
