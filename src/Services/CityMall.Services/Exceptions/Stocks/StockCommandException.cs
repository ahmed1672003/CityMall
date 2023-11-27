namespace CityMall.Services.Exceptions.Categories;
public sealed class StockCommandException : Exception
{
    public StockCommandException(string? message) : base(message) { }
    public StockCommandException(string? message, Exception? innerException) : base(message, innerException) { }
}