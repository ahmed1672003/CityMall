namespace CityMall.Specifications.Specifications.Jwts;
public sealed class AsNoTrackingGetUserJwtByJWTSpecification : Specification<UserJWT>
{
    public AsNoTrackingGetUserJwtByJWTSpecification(string jwt) :
        base(jw => jw.JWT.Equals(jwt))
    {
        StopTracking();
    }
}
