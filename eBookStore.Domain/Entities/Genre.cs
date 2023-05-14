using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class Genre:BaseEntity
    {
        public string GenreName { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
