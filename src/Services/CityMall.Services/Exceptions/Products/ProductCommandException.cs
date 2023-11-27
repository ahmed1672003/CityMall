namespace CityMall.Services.Exceptions.Products;
public sealed class ProductCommandException : Exception
{
    public ProductCommandException(string? message) : base(message) { }
    public ProductCommandException(string? message, Exception? innerException) : base(message, innerException) { }
}
