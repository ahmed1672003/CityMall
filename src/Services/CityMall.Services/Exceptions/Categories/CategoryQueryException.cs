namespace CityMall.Services.Exceptions.Categories;

public sealed class CategoryQueryException : Exception
{
    public CategoryQueryException(string? message) : base(message) { }
    public CategoryQueryException(string? message, Exception? innerException) : base(message, innerException) { }
}