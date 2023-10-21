using CityMall.Specifications.Specifications.Jwts;

namespace CityMall.Specifications.Specifications;

public sealed class SpecificationsFactory : ISpecificationsFactory
{
    public ISpecification<UserJWT> CreateUserJwtsSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Specification" => new AsNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Specification(parameters[0], parameters[1]),
            "AsNoTrackingGetUserJwtByJWTWithRefreshJWTSpecification" => new AsNoTrackingGetUserJwtByJWTWithRefreshJWTSpecification(parameters[0], parameters[1]),
            _ => throw new InvalidOperationException()
        };
    }

    public ISpecification<User> CreateUserSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingCheckDeletedDuplicatedUserByEmailSpecification" => new AsNoTrackingCheckDeletedDuplicatedUserByEmailSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDeletedDuplicatedUserByUserNameSpecification" => new AsNoTrackingCheckDeletedDuplicatedUserByUserNameSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedUserByEmailSpecification" => new AsNoTrackingCheckDuplicatedUserByEmailSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedUserByUserNameSpecification" => new AsNoTrackingCheckDuplicatedUserByUserNameSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckUnDeletedDuplicatedUserByEmailSpecification" => new AsNoTrackingCheckUnDeletedDuplicatedUserByEmailSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckUnDeletedDuplicatedUserByUserNameSpecification" => new AsNoTrackingCheckUnDeletedDuplicatedUserByUserNameSpecification(parameters[0], parameters[1]),
            "AsNoTrackingGetAllDeletedUsersSpecification" => new AsNoTrackingGetAllDeletedUsersSpecification(),
            "AsNoTrackingGetAllUnDeletedUsersSpecification" => new AsNoTrackingGetAllUnDeletedUsersSpecification(),
            "AsNoTrackingGetAllUsersSpecification" => new AsNoTrackingGetAllUsersSpecification(),
            "AsNoTrackingGetDeletedUserByIdSpecification" => new AsNoTrackingGetDeletedUserByIdSpecification(parameters[0]),
            "AsNoTrackingGetUserByEmailSpecification" => new AsNoTrackingGetUserByEmailSpecification(parameters[0]),
            "AsNoTrackingGetUserByIdSpecification" => new AsNoTrackingGetUserByIdSpecification(parameters[0]),
            "AsNoTrackingGetUserByUserNameSpecification" => new AsNoTrackingGetUserByUserNameSpecification(parameters[0]),
            "AsNoTrackingGetUnDeletedUserByUserNameSpecification" => new AsNoTrackingGetUnDeletedUserByUserNameSpecification(parameters[0]),
            "AsNoTrackingGetDeletedUserByUserNameSpecification" => new AsNoTrackingGetDeletedUserByUserNameSpecification(parameters[0]),
            "AsNoTrackingGetUnDeletedUserByEmailSpecification" => new AsNoTrackingGetUnDeletedUserByEmailSpecification(parameters[0]),
            "AsNoTrackingGetUnDeletedUserByIdSpecification" => new AsNoTrackingGetUnDeletedUserByIdSpecification(parameters[0]),
            "AsNoTrackingPaginateAllDeletedUsersSpecifications" => new AsNoTrackingPaginateAllDeletedUsersSpecifications(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsNoTrackingPaginateAllUnDeletedUsersSpecification" => new AsNoTrackingPaginateAllUnDeletedUsersSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsNoTrackingPaginateAllUsersSpecification" => new AsNoTrackingPaginateAllUsersSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsTrackingGetDeletedUserByIdSpecification" => new AsTrackingGetDeletedUserByIdSpecification(parameters[0]),
            "AsTrackingGetUnDeletedUserByIdSpecification" => new AsTrackingGetUnDeletedUserByIdSpecification(parameters[0]),
            "AsTrackingGetUnDeletedUserByUserNameSpecification" => new AsTrackingGetUnDeletedUserByUserNameSpecification(parameters[0]),
            "AsTrackingGetUnDeletedUserByEmailSpecification" => new AsTrackingGetUnDeletedUserByEmailSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
}