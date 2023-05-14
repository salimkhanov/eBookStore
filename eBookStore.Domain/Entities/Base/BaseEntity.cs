using eBookStore.Domain.Enums;

namespace eBookStore.Domain.Entities.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateByName { get; set; }
    public string UpdateByName { get; set; } 
    public EntityStatus EntityStatus { get; set; } 
    public string Note { get; set; } 






}