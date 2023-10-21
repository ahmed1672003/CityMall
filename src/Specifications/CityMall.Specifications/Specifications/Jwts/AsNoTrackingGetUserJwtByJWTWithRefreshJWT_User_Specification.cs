namespace CityMall.Specifications.Specifications.Jwts;
public sealed class AsNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Specification : Specification<UserJWT>
{
    public AsNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Specification(string jwt, string refreshJwt)
        : base(jw => jw.JWT.Equals(jwt) && jw.RefreshJWT.Equals(refreshJwt) && jw.IsRefreshJWTUsed)
    {
        StopTracking();
        AddIncludes(u => u.User);
    }
}
