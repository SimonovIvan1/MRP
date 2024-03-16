using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Domain.Entity
{
#nullable disable
    internal class Storehouse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Goods> Goods { get; set; }

    }
}
