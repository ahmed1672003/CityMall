﻿namespace CityMall.Domain.Entities.Identity;

[PrimaryKey(nameof(Id), nameof(UserId))]
public sealed class UserJWT : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public string UserId { get; set; }

    [Required]
    [MaxLength(4000)]
    public string JWT { get; set; }

    [Required]
    [MaxLength(4000)]
    public string RefreshJWT { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime JWTExpirationDate { get; set; }

    [Required]
    public DateTime RefreshJWTExpirtionDate { get; set; }

    [AllowNull]
    public DateTime? RefreshJWTRevokedDate { get; set; }

    [Required]
    public bool IsRefreshJWTUsed { get; set; }

    [NotMapped]
    public bool IsRefreshJWTActive => RefreshJWTRevokedDate is null && !IsRefreshJWTExpired;

    [NotMapped]
    public bool IsRefreshJWTExpired => DateTime.UtcNow >= RefreshJWTExpirtionDate;

    [AllowNull]
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public UserJWT()
    {
        CreatedAt = DateTime.Now;
        IsRefreshJWTUsed = true;
    }
}
