﻿namespace MRP_DAL.Entity
{
    internal class OrderStatus
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
