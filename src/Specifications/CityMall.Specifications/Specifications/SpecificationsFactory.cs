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
            "AsTrackingGetUnDeletedUserByEmail_UserjWTs_Specification" => new AsTrackingGetUnDeletedUserByEmail_UserjWTs_Specification(parameters[0]),
            "AsTrackingGetUnDeletedUserByUserName_UserjWTs_Specification" => new AsTrackingGetUnDeletedUserByUserName_UserjWTs_Specification(parameters[0]),
            "AsTrackingGetDeletedUserByIdSpecification" => new AsTrackingGetDeletedUserByIdSpecification(parameters[0]),
            "AsTrackingGetUnDeletedUserByIdSpecification" => new AsTrackingGetUnDeletedUserByIdSpecification(parameters[0]),
            "AsTrackingGetUnDeletedUserByUserNameSpecification" => new AsTrackingGetUnDeletedUserByUserNameSpecification(parameters[0]),
            "AsTrackingGetUnDeletedUserByEmailSpecification" => new AsTrackingGetUnDeletedUserByEmailSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<Role> CreateRoleSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetAllRoleByRoleNamesSpecification" => new AsNoTrackingGetAllRoleByRoleNamesSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<Address> CreateAddressSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetUnDeletedAddressByIdSpecification" => new AsNoTrackingGetUnDeletedAddressByIdSpecification(parameters[0]),
            "AsTrackingGetUnDeletedAddressByIdSpecification" => new AsTrackingGetUnDeletedAddressByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<Customer> CreateCustomerSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetUnDeletedCustomerByIdSpecification" => new AsNoTrackingGetUnDeletedCustomerByIdSpecification(parameters[0]),
            "AsNoTrackingGetAllUnDeletedCustomerSpecification" => new AsNoTrackingGetAllUnDeletedCustomerSpecification(),
            "AsNoTrackingGetAllDeletedCustomerSpecification" => new AsNoTrackingGetAllDeletedCustomerSpecification(),
            "AsNoTrackingGetAllCustomerSpecification" => new AsNoTrackingGetAllCustomerSpecification(),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<Stock> CreateStockSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetAllDeletedStocksSpecification" => new AsNoTrackingGetAllDeletedStocksSpecification(),
            "AsNoTrackingGetAllStocksSpecification" => new AsNoTrackingGetAllStocksSpecification(),
            "AsNoTrackingGetAllUnDeletedStocksSpecification" => new AsNoTrackingGetAllUnDeletedStocksSpecification(),
            "AsNoTrackingGetUnDeletedStockByIdSpecification" => new AsNoTrackingGetUnDeletedStockByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<Category> CreateCategorySpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetAllCategoriesSpecification" => new AsNoTrackingGetAllCategoriesSpecification(),
            "AsNoTrackingGetAllDeletedCategoriesSpecification" => new AsNoTrackingGetAllDeletedCategoriesSpecification(),
            "AsNoTrackingGetAllUnDeletedCategoriesSpecification" => new AsNoTrackingGetAllUnDeletedCategoriesSpecification(),
            "AsNoTrackingGetUnDeletedCategoryByIdSpecification" => new AsNoTrackingGetUnDeletedCategoryByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException(),
        };
    }
    public ISpecification<SubCategory> CreateSubCategorySpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetAllDeletedSubCategoriesSpecification" => new AsNoTrackingGetAllDeletedSubCategoriesSpecification(),
            "AsNoTrackingGetAllSubCategoriesSpecification" => new AsNoTrackingGetAllSubCategoriesSpecification(),
            "AsNoTrackingGetAllUnDeletedSubCategoriesSpecification" => new AsNoTrackingGetAllUnDeletedSubCategoriesSpecification(),
            "AsNoTrackingGetUnDeletedSubCategoryByIdSpecification" => new AsNoTrackingGetUnDeletedSubCategoryByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException(),
        };
    }
    public ISpecification<Product> CreateProductSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetAllDeletedProductsSpecification" => new AsNoTrackingGetAllDeletedProductsSpecification(),
            "AsNoTrackingGetAllProductsSpecification" => new AsNoTrackingGetAllProductsSpecification(),
            "AsNoTrackingGetAllUnDeletedProductsSpecification" => new AsNoTrackingGetAllUnDeletedProductsSpecification(),
            "AsNoTrackingGetDeletedProductBySKUSpecification" => new AsNoTrackingGetDeletedProductBySKUSpecification(parameters[0]),
            "AsNoTrackingGetProductBySKUSpecification" => new AsNoTrackingGetProductBySKUSpecification(parameters[0]),
            "AsNoTrackingGetUnDeletedProductByIdSpecification" => new AsNoTrackingGetUnDeletedProductByIdSpecification(parameters[0]),
            "AsNoTrackingGetUnDeletedProductBySKUSpecification" => new AsNoTrackingGetUnDeletedProductBySKUSpecification(parameters[0]),
            "AsNoTrackingCheckDeletedDuplicatedProductBySKUSpecification" => new AsNoTrackingCheckDeletedDuplicatedProductBySKUSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckUnDeletedDuplicatedProductBySKUSpecification" => new AsNoTrackingCheckUnDeletedDuplicatedProductBySKUSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedProductBySKUSpecification" => new AsNoTrackingCheckDuplicatedProductBySKUSpecification(parameters[0], parameters[1]),
            _ => throw new InvalidOperationException()
        };
    }
}