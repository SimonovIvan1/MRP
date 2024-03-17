namespace MRP_DAL.Entity
{
#nullable disable
    internal class GoodsDAL
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }
        public Guid StorehouseId { get; set; }
        public Guid? ParentItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsMainItem { get; set; }
        public SupplierDAL Supplier { get; set; }
        public StorehouseDAL Storehouse { get; set; }
    }
}
