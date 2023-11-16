namespace CityMall.Specifications.Specifications.Users;
public sealed class AsTrackingGetUnDeletedUserByEmail_UserjWTs_Specification : Specification<User>
{
    public AsTrackingGetUnDeletedUserByEmail_UserjWTs_Specification(string email)
        : base(u => u.Email.Equals(email))
    {
        AddIncludes(u => u.UserJWTs);
    }
}
