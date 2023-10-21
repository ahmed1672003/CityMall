using System.ComponentModel.DataAnnotations.Schema;

namespace CityMall.Domain.Bases;

[NotMapped]
public class BaseEntity
{
    public string Id { get; set; }
    public BaseEntity()
    {
        Id = $"{Guid.NewGuid().ToString().Replace("-", string.Empty)}{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    }
}
