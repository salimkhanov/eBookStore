﻿using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; } = default!;
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}