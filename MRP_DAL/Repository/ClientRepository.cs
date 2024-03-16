using ExternalModels;
using Microsoft.EntityFrameworkCore;
using MRP_DAL.Entity;

namespace MRP_DAL.Repository
{
    public class ClientRepository : IRepository<ClientDto>
    {
        private AppDbContext _db;

        public ClientRepository(DbContextOptions<AppDbContext> db)
        {
            _db = new AppDbContext(db);
        }

        public async Task Create(ClientDto item)
        {
            var client = new Client()
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Surname = item.Surname,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber
            };
            await _db.Client.AddAsync(client);
            await Save();
        }

        public async Task Delete(Guid id)
        {
            var client = await _db.Client.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null) return;
            _db.Client.Remove(client);
        }

        public ClientDto Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Update(ClientDto item)
        {
            throw new NotImplementedException();
        }
    }
}
