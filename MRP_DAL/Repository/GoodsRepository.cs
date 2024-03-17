using ExternalModels;
using Microsoft.EntityFrameworkCore;
using MRP_DAL.Entity;

namespace MRP_DAL.Repository
{
    public class GoodsRepository : IRepository<GoodsDto>
    {
        private readonly AppDbContext _db;

        public GoodsRepository(DbContextOptions<AppDbContext> db)
        {
            _db = new AppDbContext(db);
        }
#nullable enable
        public async Task Create(GoodsDto item)
        {
            if (item.Id != null)
            {
                var clientDb = await _db.Goods.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (clientDb != null) throw new Exception("Товар уже есть в базе!");
            }
            var client = new Goods()
            {
                Id = Guid.NewGuid(),
                Description = item.Description,
                Name = item.Name,
                Price = item.Price,
                StorehouseId = item.StorehouseId,
                SupplierId = item.SupplierId,
            };
            await _db.Goods.AddAsync(client);
            await Save();
        }

        public async Task Delete(Guid id)
        {
            var client = await _db.Client.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null) return;
            _db.Client.Remove(client);
        }

        public async Task<GoodsDto?> Get(Guid id)
        {
            var client = await _db.Goods.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null) return default;
            var clientDto = new GoodsDto()
            {
                Id = client.Id,
                Description = client.Description,
                Name = client.Name,
                Price = client.Price,
                StorehouseId = client.StorehouseId,
                SupplierId = client.SupplierId
            };
            return clientDto;
        }

        public async Task<GoodsDto[]> GetAll()
        {
            var clients = await _db.Goods.ToArrayAsync();
            var clientsDto = new List<GoodsDto>();
            foreach (var client in clients)
            {
                var clientDto = new GoodsDto()
                {
                    Id = client.Id,
                    Description = client.Description,
                    Name = client.Name,
                    Price = client.Price,
                    StorehouseId = client.StorehouseId,
                    SupplierId = client.SupplierId
                };
                clientsDto.Add(clientDto);
            }
            return clientsDto.ToArray();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Update(GoodsDto item)
        {
            var client = await _db.Goods.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (client == null) return;
            if (!string.IsNullOrWhiteSpace(item.Name))
                client.Name = item.Name;
            if (!string.IsNullOrWhiteSpace(item.Description))
                client.Description = item.Description;
            _db.Update(client);
            await Save();
        }
    }
}