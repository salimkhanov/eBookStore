using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class PaperType:BaseEntity
    {
        public string PaperTypeName { get; set; }
        public ICollection<Book> BookCovers { get; set; }
        public ICollection<Book> BookPapers { get; set; }

    }
}
