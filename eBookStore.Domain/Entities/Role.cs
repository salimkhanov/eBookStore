﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public  class Role:IdentityRole
    {
        public int Id { get; set; }
    }
}
