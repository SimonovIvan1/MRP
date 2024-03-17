using Microsoft.EntityFrameworkCore;
using MRP_DAL;

namespace MRP_Domain.Helpers
{
    public class OrderHelper
    {
        private readonly AppDbContext _db;

        public OrderHelper(DbContextOptions<AppDbContext> db)
        {
            _db = new AppDbContext(db);
        }
    }
}
