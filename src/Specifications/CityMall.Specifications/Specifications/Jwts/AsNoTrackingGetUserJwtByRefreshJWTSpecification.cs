namespace CityMall.Specifications.Specifications.Jwts;
public sealed class AsNoTrackingGetUserJwtByRefreshJWTSpecification : Specification<UserJWT>
{
    public AsNoTrackingGetUserJwtByRefreshJWTSpecification(string refreshJwt)
        : base(jw => jw.RefreshJWT.Equals(refreshJwt))
    {
        StopTracking();
    }

}
