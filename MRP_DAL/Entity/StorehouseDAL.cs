﻿namespace MRP_DAL.Entity
{
#nullable disable
    internal class StorehouseDAL
    {
        public Guid Id { get; set; }
        public Guid GoodId { get; set; }
        public int Quantity { get; set; }
        public DateTime CountingTime { get; set; }
        public GoodsDAL Good { get; set; }
    }
}
