using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Country : BaseEntity
{
    public string CountryName { get; set; }
    public ICollection<Address> Addresses { get; set; }
}
