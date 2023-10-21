namespace CityMall.Domain.Exceptions.Images;
public class InvalidDeleteImageException : Exception
{
    public InvalidDeleteImageException() { }
    public InvalidDeleteImageException(string message = "Upload Image Failed !") : base(message) { }
    public InvalidDeleteImageException(string message, Exception innerException) : base(message, innerException) { }
}
