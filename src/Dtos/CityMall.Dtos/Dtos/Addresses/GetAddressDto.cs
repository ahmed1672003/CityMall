namespace CityMall.Dtos.Dtos.Addresses;

public sealed class GetAddressDto
{
    public string Id { get; set; }
    public string CustomerId { get; set; }

    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string Governorate { get; set; }
    public string Country { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}