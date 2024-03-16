using Microsoft.EntityFrameworkCore;
using MRP_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        internal DbSet<GoodsInOrder> Basket { get; set; }
        internal DbSet<Client> Client { get; set; }
        internal DbSet<Goods> Goods { get; set; }
        internal DbSet<GoodsForSupplier> GoodsForSuppliers { get; set; }
        internal DbSet<Order> Order { get; set; }
        internal DbSet<Storehouse> Storehouse { get; set; }
        internal DbSet<Supplier> Supplier { get; set; }
    }
}