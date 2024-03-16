namespace ExternalModels
{
#nullable disable
    public class GoodsInOrderDto
    {
        public Guid Id { get; set; }
        public Guid GoodsId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
