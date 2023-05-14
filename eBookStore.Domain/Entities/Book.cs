using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class Book:BaseEntity
    {
        public string OriginalName { get; set; }
        public string Summary { get; set; }
        public int PageNumber { get; set; }
        public int Edition { get; set; }
        public int BookHeight { get; set; }
        public int BookWidth { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Translator> Translators { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CoverTypeId { get; set; }
        public PaperType CoverType { get; set; }
        public int Papertypeid { get; set; }
        public PaperType PaperType { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
