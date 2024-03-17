using ExternalModels.PublicApiDto;
using Microsoft.EntityFrameworkCore;
using MRP_DAL;
using MRP_Domain.Entity;
using MRP_Domain.Enum;

namespace MRP_Domain.Helpers
{
    public class OrderHelper
    {
        private readonly AppDbContext _db;

        public OrderHelper(DbContextOptions<AppDbContext> db)
        {
            _db = new AppDbContext(db);
        }
        public async Task<Order> CreateOrder(NewOrderDTO newOrder)
        {
            var order = new Order()
            { 
                Id = Guid.NewGuid(),
                DateTimeCreated = DateTime.Now,
                Address = newOrder.Address,
                ClientId = newOrder.ClientId,
                OrderStatusId = (int)OrderStatusType.Created,
                StatusDescription = "Заказ создан"
            };
            return order;
        }
    }
}
