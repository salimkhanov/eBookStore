using eBookStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.DTOs.Role
{
    public class GetAllRoleDTO
    {
        public int Id { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public int OrderIndex { get; set; }
    }
}
