namespace CityMall.Specifications.Specifications.Jwts;

public sealed class AsNoTrackingGetUserJwtByJWTWithRefreshJWTSpecification : Specification<UserJWT>
{
    public AsNoTrackingGetUserJwtByJWTWithRefreshJWTSpecification(string jwt, string refreshJwt) :
        base(jw => jw.JWT.Equals(jwt) && jw.RefreshJWT.Equals(refreshJwt) && jw.IsRefreshJWTUsed)
    {
        StopTracking();
    }
}


