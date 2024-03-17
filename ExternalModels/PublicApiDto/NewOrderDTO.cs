namespace ExternalModels.PublicApiDto
{
    public class NewOrderDTO
    {
#nullable disable
        public Guid ClientId { get; set; }
        public string Address { get; set; }
        public List<GoodsInOrderDto> GoodsInOrder { get; set; }
    }
}
