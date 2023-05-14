using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class Order:BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public DateTime Shipdate { get; set; }
        public DateTime ShipStreet { get; set; }
        public DateTime ShipCity { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
