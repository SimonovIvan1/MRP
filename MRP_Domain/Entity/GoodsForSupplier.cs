using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Domain.Entity
{
#nullable disable
    internal class GoodsForSupplier
    {
        public Guid Id { get; set; }
        public Guid GoodsId { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
