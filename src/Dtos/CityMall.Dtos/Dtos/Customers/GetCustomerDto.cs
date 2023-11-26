namespace CityMall.Dtos.Dtos.Customers;

public sealed class GetCustomerDto
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string FirstPhone { get; set; }
    public string? SecondPhone { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}