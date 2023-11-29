namespace CityMall.Services.Exceptions.Products;
public sealed class ProductImageCommandException : Exception
{
    public ProductImageCommandException(string? message) : base(message) { }
    public ProductImageCommandException(string? message, Exception? innerException) : base(message, innerException) { }
}