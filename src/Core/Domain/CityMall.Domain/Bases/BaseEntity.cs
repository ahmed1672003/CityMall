namespace CityMall.Domain.Bases;

[NotMapped]
public class BaseEntity
{
    public virtual string Id { get; set; }
    public BaseEntity()
    {
        Id = $"{Guid.NewGuid().ToString().Replace("-", string.Empty)}{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    }
}
