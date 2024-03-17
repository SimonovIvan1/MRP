namespace MRP_DAL.Entity
{
#nullable disable
    internal class GoodsInOrderDAL
    {
        public Guid Id { get; set; }
        public Guid GoodsId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public double Costs { get; set; }
        public OrderDAL Order { get; set; }
        public GoodsDAL Goods { get; set; }
    }
}
