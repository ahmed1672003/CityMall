namespace CityMall.Services.Exceptions.Products;

public sealed class ProductQueryException : Exception
{
    public ProductQueryException(string? message) : base(message) { }
    public ProductQueryException(string? message, Exception? innerException) : base(message, innerException) { }
}