﻿using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Country : BaseEntity
{   
    public string Name { get; set; } = default!;
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}
