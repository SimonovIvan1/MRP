using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRP_DAL.Entity
{
#nullable disable
    internal class OrderDAL
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string Address { get; set; }
        public double TotalCost { get; set; }
        public int OrderStatusId { get; set; }
#nullable enable
        public string? StatusDescription { get; set; }
        public DateTime? ExpectedDelivery { get; set; }
#nullable disable
        public ClientDAL Client { get; set; }
        public OrderStatusDAL OrderStatus { get; set; }
        public List<GoodsInOrderDAL> GoodsInOrder { get; set; }
    }
}
