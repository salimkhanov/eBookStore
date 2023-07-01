using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class OrderStatus:BaseEntity
{
    public string Status { get; set; }
}
