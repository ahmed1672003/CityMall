namespace CityMall.Services.Exceptions.Categories;

public sealed class StockQueryException : Exception
{
    public StockQueryException(string? message) : base(message) { }
    public StockQueryException(string? message, Exception? innerException) : base(message, innerException) { }
}





