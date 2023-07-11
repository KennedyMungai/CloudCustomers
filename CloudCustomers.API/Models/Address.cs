using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCustomers.API.Models
{
    public class Address
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
    }
}