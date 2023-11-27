namespace CityMall.Services.Exceptions.Categories;
public sealed class CategoryCommandException : Exception
{
    public CategoryCommandException(string? message) : base(message) { }
    public CategoryCommandException(string? message, Exception? innerException) : base(message, innerException) { }
}
