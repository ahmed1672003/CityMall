namespace CityMall.Specifications.Specifications.Users;
public sealed class AsTrackingGetUnDeletedUserByUserName_UserjWTs_Specification : Specification<User>

{
    public AsTrackingGetUnDeletedUserByUserName_UserjWTs_Specification(string userName) :
        base(u => u.UserName.Equals(userName))
    {
        AddIncludes(u => u.UserJWTs);
    }
}
