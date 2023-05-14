using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class Publisher:BaseEntity
    {
        public string PublisherName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
