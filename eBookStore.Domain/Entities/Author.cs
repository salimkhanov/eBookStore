using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class Author:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Resume { get; set; }
        public string Email { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Tvitter { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
