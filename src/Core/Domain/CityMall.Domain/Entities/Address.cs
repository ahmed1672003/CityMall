namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Address : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MinLength(255)]
    [MaxLength(255)]
    public string StreetName { get; set; }

    [Required]
    [MinLength(255)]
    [MaxLength(255)]
    public string StreetNumber { get; set; }

    [Required]
    [MinLength(255)]
    [MaxLength(255)]
    public string City { get; set; }


    [Required]
    [MinLength(255)]
    [MaxLength(255)]
    public string Governorate { get; set; }

    [Required]
    [MinLength(255)]
    [MaxLength(255)]
    public string Country { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
