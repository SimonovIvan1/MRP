using ExternalModels.PublicApiDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MRP_DAL.Entity;
using MRP_Domain.Entity;
using MRP_Domain.Enum;
using static System.Net.Mime.MediaTypeNames;

namespace MRP_DAL.Helpers
{
    public class OrderHelper
    {
        private readonly AppDbContext _db;

        public OrderHelper(DbContextOptions<AppDbContext> db)
        {
            _db = new AppDbContext(db);
        }

        public async Task<Order[]> GetAll()
        {
            var ordersDal = await _db.Order.ToArrayAsync();
            var orders = new List<Order>();
            foreach (var orderDal in ordersDal)
            {
                var order = new Order()
                {
                    Id = orderDal.Id,
                    DateTimeCreated = orderDal.DateTimeCreated,
                    Address = orderDal.Address,
                    ClientId = orderDal.ClientId,
                    OrderStatusId = orderDal.OrderStatusId,
                    StatusDescription = orderDal.StatusDescription,
                    ExpectedDelivery = orderDal.ExpectedDelivery,
                    TotalCost = orderDal.TotalCost
                };
                orders.Add(order);
            }
            return orders.ToArray();
        }

        public async Task<Order> CreateOrder(NewOrderDTO newOrder)
        {
            var totalCost = 0.0;
            var order = new Order()
            { 
                Id = Guid.NewGuid(),
                DateTimeCreated = DateTime.UtcNow,
                Address = newOrder.Address,
                ClientId = newOrder.ClientId,
                OrderStatusId = (int)OrderStatusType.Created,
                StatusDescription = "Заказ создан"
            };
            var goods = await _db.Goods.ToArrayAsync();
            var newGoodsInOrder = new List<GoodsInOrderDAL>();
            foreach (var good in newOrder.GoodsInOrder)
            {
                totalCost += good.Costs;
                var goodInDb = goods.FirstOrDefault(x => x.Id == good.GoodsId);
                var newGoodInOrder = new GoodsInOrderDAL
                {
                    Id = Guid.NewGuid(),
                    Costs = good.Costs,
                    GoodsId = good.GoodsId,
                    OrderId = order.Id,
                    Quantity = good.Quantity,
                };
                newGoodsInOrder.Add(newGoodInOrder);
            }
            order.TotalCost = totalCost;
            var newOrderDb = new OrderDAL()
            {
                Id = order.Id,
                DateTimeCreated = DateTime.UtcNow,
                Address = order.Address,
                ClientId = order.ClientId,
                OrderStatusId = (int)OrderStatusType.InProcessing,
                StatusDescription = "Заказ на стадии обработки. Дата возможного получения товаров " +
                "со склада будет доступна после обработки. Пожалуйста, ожидайте.",
                TotalCost = order.TotalCost
            };
            await _db.Order.AddAsync(newOrderDb);
            await _db.SaveChangesAsync();
            await _db.AddRangeAsync(newGoodsInOrder);
            await _db.SaveChangesAsync();
            return order;
        }

        public async void ProcessOrder()
        {
            var order = await _db.Order
                .Where(x => x.OrderStatusId == (int)OrderStatusType.InProcessing)
                .Include(x => x.GoodsInOrder)
                .FirstOrDefaultAsync();
            if (order == null) return;
            var parentItemsDal = await _db.Goods
                .Where(x => x.IsMainItem == false)
                .ToArrayAsync();
            var parentItems = await GetParentItems(order.GoodsInOrder);
            var needItems = new List<GoodsDAL>();
            while (parentItems.Count != 0)
            {
                var copyParents = new List<GoodsDAL>(parentItems);
                parentItems.Clear();
                foreach (var parentItem in copyParents)
                {
                    if (parentItem.ParentItemId == null) continue;
                    var needItem = parentItemsDal.FirstOrDefault(x => x.Id == parentItem.ParentItemId);
                    if (needItem == null) throw new Exception("Зависимого товара не существует!");
                    needItems.Add(needItem);
                    parentItems.Add(needItem);
                }
            }
            order.OrderStatusId = (int)OrderStatusType.AwaitingSupply;
            order.ExpectedDelivery = DateTime.UtcNow.AddDays(7);
            order.StatusDescription = $"Ваши товары будут доступны для получения после {order.ExpectedDelivery}";
            _db.Order.Update(order);
            await _db.SaveChangesAsync();
        }

        private async Task<List<GoodsDAL>> GetParentItems(List<GoodsInOrderDAL> goods)
        {
            var parentItems = new List<GoodsDAL>();
            foreach (var item in goods)
            {
                var good = await _db.Goods.FirstOrDefaultAsync(x => x.Id == item.GoodsId);
                if (good == null) throw new Exception("Товара не существует");
                var parentItem = await _db.Goods.FirstOrDefaultAsync(x => x.Id == good.ParentItemId);
                if (parentItem == null) continue;
                parentItems.Add(parentItem);
            }
            return parentItems;
        }
    }
}
