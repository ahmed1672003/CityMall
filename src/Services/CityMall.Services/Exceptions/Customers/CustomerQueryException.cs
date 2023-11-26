namespace CityMall.Services.Exceptions.Customers;

public class CustomerQueryException : Exception
{
    public CustomerQueryException(string? message) : base(message) { }
    public CustomerQueryException(string? message, Exception? innerException) : base(message, innerException) { }
}