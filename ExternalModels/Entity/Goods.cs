namespace MRP_DAL.Entity
{
#nullable disable
    internal class Goods
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }
        public Guid StorehouseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
