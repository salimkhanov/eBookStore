using eBookStore.Domain.Entities.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookStore.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int BookLanguageId { get; set; }
    [NotMapped]
    public IFormFile BookImage { get; set; } = default!;
    public string? ImagePath { get; set; }
    public int PageCount { get; set; }  
    public DateTime PublicationDate { get; set; }
    public int PublisherId { get; set; }    
    public int QtyInStock { get; set; }
    public double Price { get; set; }
    public int BookGenreId { get; set; }
    public int DiscountId { get; set; } 

    #region Nagigation Property
    public BookLanguage BookLanguage { get; set; } = default!;
    public BookGenre BookGenre { get; set; } = default!;
    public Publisher Publisher { get; set; } = default!;
    public Discount Discount { get; set; } = default!;
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    #endregion
}
