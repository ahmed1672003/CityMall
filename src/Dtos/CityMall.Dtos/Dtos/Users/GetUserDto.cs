using CityMall.Domain.Enums;

namespace CityMall.Dtos.Dtos.Users;
public sealed class GetUserDto
{
    public string Id { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Gander Gander { get; set; }
    public string? PhoneNumber { get; set; }
    public string? WhatsAppNumber { get; set; }
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
