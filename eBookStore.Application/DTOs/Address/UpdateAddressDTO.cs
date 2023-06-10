using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.DTOs.Address
{
    public class UpdateAddressDTO
    {
        public int Id { get; set; }
        public int UnitNumber { get; set; }
        public int StreetNumber { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public int CountryId { get; set; }
    }
}
