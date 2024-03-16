using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Domain.Entity
{
    internal class GoodsInOrder
    {
        public Guid Id { get; set; }
        public Guid GoodsId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
