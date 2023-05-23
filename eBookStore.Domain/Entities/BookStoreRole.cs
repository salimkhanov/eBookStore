using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class BookStoreRole : IdentityRole<int>
    {
        public EntityStatus Status { get; set; } = EntityStatus.IsActive;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}