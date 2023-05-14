using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public  class User:IdentityUser
    {
        public int Id { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
