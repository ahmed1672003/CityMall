namespace CityMall.Dtos.Dtos.SubCategories;

public sealed class GetSubCategoryDto
{
    public string Id { get; set; }
    public string CategoryId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}