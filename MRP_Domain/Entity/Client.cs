using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Domain.Entity
{
    internal class Client
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname{ get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Order>? Orders { get; set; }
    }
}