namespace CityMall.Specifications.Contracts;
public interface ISpecificationsFactory
{
    ISpecification<User> CreateUserSpecifications(Type type, params dynamic[] parameters);
    ISpecification<UserJWT> CreateUserJwtsSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Role> CreateRoleSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Address> CreateAddressSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Customer> CreateCustomerSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Stock> CreateStockSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Category> CreateCategorySpecifications(Type type, params dynamic[] parameters);
    ISpecification<SubCategory> CreateSubCategorySpecifications(Type type, params dynamic[] parameters);
}