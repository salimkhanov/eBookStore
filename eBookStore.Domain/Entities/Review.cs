using eBookStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
   public class Review:BaseEntity
    {

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public string Content { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ReviewId { get; set; }
        public Review ResponseOfReview{ get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
