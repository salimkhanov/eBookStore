using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class OrderProduct:BaseEntity
    {
        public int ProductQuantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
