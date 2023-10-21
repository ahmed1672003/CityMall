﻿namespace CityMall.Domain.Entities.Identity;

[PrimaryKey(nameof(Id))]
[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public sealed class User : IdentityUser<string>, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [MaxLength(64)]
    public override string Id { get; set; }
    public override string UserName { get; set; } = null!;
    public override string NormalizedUserName { get; set; } = null!;
    public override string Email { get; set; } = null!;
    public override string NormalizedEmail { get; set; } = null!;
    public override bool EmailConfirmed { get; set; }
    public string EmailConfirmationToken { get; set; } = null!;
    public Gander Gander { get; set; }

    [MaxLength(255)]
    public override string? PhoneNumber { get; set; }

    [MaxLength(255)]
    public string? WhatsAppNumber { get; set; }

    [NotMapped]
    public override bool PhoneNumberConfirmed { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<UserJWT> UserJWTs { get; set; }
    public List<UserRoleMapper> UserRoles { get; set; }

    public User()
    {
        // 257EAEEEEA724D7EB50B8B41A4DDE0B6257EAEEEEA724D7EB50B8B41A4DDE0B6
        Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);
        IsDeleted = false;
        UserJWTs = new(0);
        UserRoles = new(0);
    }
}
