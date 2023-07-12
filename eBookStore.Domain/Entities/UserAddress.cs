﻿using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class UserAddress : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public int AddressId { get; set; }
    public Address Address { get; set; } = default!;
    public bool IsDefault { get; set; } 
}
