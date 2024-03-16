namespace MRP_DAL.Entity
{
    internal class Supplier
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<Goods> Goods { get; set; }
    }
}
