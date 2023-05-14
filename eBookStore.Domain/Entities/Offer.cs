using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class Offer:BaseEntity
    {
        public DateTime OfferStartDate { get; set; }
        public DateTime OfferEndDate { get; set; }
        public float OfferPrice { get; set; }
        public string OfferContent { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
