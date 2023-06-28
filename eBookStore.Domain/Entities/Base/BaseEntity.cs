using eBookStore.Domain.Enums;

namespace eBookStore.Domain.Entities.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;
}
