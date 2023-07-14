﻿using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class BookGenre : BaseEntity 
{
    public string Name { get; set; } = default!;
    public ICollection<Book> Books { get; set; } = new List<Book>();   
}
