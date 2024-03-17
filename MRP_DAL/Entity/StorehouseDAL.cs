namespace MRP_DAL.Entity
{
#nullable disable
    internal class StorehouseDAL
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<GoodsDAL> Goods { get; set; }
    }
}
