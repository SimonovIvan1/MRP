using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRP_Domain.Entity
{
#nullable disable
    internal class Order
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string Address { get; set; }
        public double TotalCost { get; set; }
        public int OrderStatusId { get; set; }
        public Client Client { get; set; }
        public List<GoodsInOrder> GoodsInOrder { get; set; }
    }
}
