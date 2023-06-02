using eBookStore.Domain.Enums;

namespace eBookStore.Domain.Entities.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public EntityStatus EntityStatus { get; set; }
}