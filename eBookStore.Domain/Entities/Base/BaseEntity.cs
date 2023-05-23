using eBookStore.Domain.Enums;

namespace eBookStore.Domain.Entities.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public int CreateBy { get; set; }
    public int UpdateBy { get; set; }
    public EntityStatus EntityStatus { get; set; }
    public string Note { get; set; }
}