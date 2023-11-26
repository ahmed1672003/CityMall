namespace CityMall.Services.Exceptions.Addresses;
public sealed class AddressCommandException : Exception
{
    public AddressCommandException(string? message) : base(message) { }
    public AddressCommandException(string? message, Exception? innerException) : base(message, innerException) { }
}
