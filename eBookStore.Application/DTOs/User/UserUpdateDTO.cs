using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.DTOs.User
{
    public class UserUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}
