namespace CityMall.Services.Exceptions.SubCategories;

public sealed class SubCategoryQueryException : Exception
{
    public SubCategoryQueryException(string? message) : base(message) { }
    public SubCategoryQueryException(string? message, Exception? innerException) : base(message, innerException) { }
}

