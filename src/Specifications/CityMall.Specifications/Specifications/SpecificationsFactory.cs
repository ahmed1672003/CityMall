using CityMall.Specifications.Contracts;

namespace CityMall.Specifications.Specifications;

public sealed class SpecificationsFactory : ISpecificationsFactory
{
    public ISpecification<User> CreateUserSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            _ => throw new InvalidOperationException()
        };
    }
}