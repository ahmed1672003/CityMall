namespace CityMall.Services.Exceptions.SubCategories;

public sealed class SubCategoryCommandException : Exception
{
    public SubCategoryCommandException(string? message) : base(message) { }
    public SubCategoryCommandException(string? message, Exception? innerException) : base(message, innerException) { }
}

