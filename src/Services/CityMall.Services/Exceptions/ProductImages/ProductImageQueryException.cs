namespace CityMall.Services.Exceptions.Products;

public sealed class ProductImageQueryException : Exception
{
    public ProductImageQueryException(string? message) : base(message) { }
    public ProductImageQueryException(string? message, Exception? innerException) : base(message, innerException) { }
}