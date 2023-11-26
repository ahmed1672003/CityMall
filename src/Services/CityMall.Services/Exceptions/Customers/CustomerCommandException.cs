namespace CityMall.Services.Exceptions.Customers;
public sealed class CustomerCommandException : Exception
{
    public CustomerCommandException(string? message) : base(message) { }
    public CustomerCommandException(string? message, Exception? innerException) : base(message, innerException) { }
}
