﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRP_DAL.Repository;
using MRP_DAL;
using MRP_DAL.Helpers;
using ExternalModels.PublicApiDto;

namespace MRP_Admin_Api.Controllers
{
    [ApiController]

    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly OrderHelper _orderHelper;

        public OrderController(DbContextOptions<AppDbContext> db)
        {
            _orderHelper = new OrderHelper(db);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewOrderDTO newOrder) => Ok(await _orderHelper.CreateOrder(newOrder));
    }
}
