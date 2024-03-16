namespace MRP_DAL.Entity
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
