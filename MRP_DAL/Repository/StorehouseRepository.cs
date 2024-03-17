using ExternalModels;
using Microsoft.EntityFrameworkCore;
using MRP_DAL.Entity;

namespace MRP_DAL.Repository
{
    public class StorehouseRepository : IRepository<StorehouseDto>
    {
        private readonly AppDbContext _db;

        public StorehouseRepository(DbContextOptions<AppDbContext> db)
        {
            _db = new AppDbContext(db);
        }
#nullable enable
        public async Task Create(StorehouseDto item)
        {
            if (item.Id != null)
            {
                var clientDb = await _db.Storehouse.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (clientDb != null) throw new Exception("Клиент уже есть в базе!");
            }
            var client = new Storehouse()
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Address = item.Address
            };
            await _db.Storehouse.AddAsync(client);
            await Save();
        }

        public async Task Delete(Guid id)
        {
            var client = await _db.Storehouse.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null) return;
            _db.Storehouse.Remove(client);
        }

        public async Task<StorehouseDto?> Get(Guid id)
        {
            var client = await _db.Storehouse.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null) return default;
            var clientDto = new StorehouseDto()
            {
                Id = client.Id,
                Name = client.Name,
                Address = client.Address
            };
            return clientDto;
        }

        public async Task<StorehouseDto[]> GetAll()
        {
            var clients = await _db.Storehouse.ToArrayAsync();
            var clientsDto = new List<StorehouseDto>();
            foreach (var client in clients)
            {
                var clientDto = new StorehouseDto()
                {
                    Id = client.Id,
                    Name = client.Name,
                    Address = client.Address
                };
                clientsDto.Add(clientDto);
            }
            return clientsDto.ToArray();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Update(StorehouseDto item)
        {
            var client = await _db.Storehouse.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (client == null) return;
            if (!string.IsNullOrWhiteSpace(item.Name))
                client.Name = item.Name;
            if (!string.IsNullOrWhiteSpace(item.Address))
                client.Address = item.Address;
            _db.Update(client);
            await Save();
        }
    }
}
