namespace MRP_DAL.Entity
{
#nullable disable
    internal class GoodsInOrder
    {
        public Guid Id { get; set; }
        public Guid GoodsId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Goods Goods { get; set; }
    }
}
