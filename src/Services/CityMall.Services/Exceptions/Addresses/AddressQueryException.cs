namespace CityMall.Services.Exceptions.Addresses;
public sealed class AddressQueryException : Exception
{
    public AddressQueryException(string? message) : base(message) { }
    public AddressQueryException(string? message, Exception innerException) : base(message, innerException) { }
}
