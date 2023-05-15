using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class Product:BaseEntity
    {   
        public float Price { get; set; }
        public int StockCount { get; set; }
        public int SoldCount { get; set; }
        public int BasketCount { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
