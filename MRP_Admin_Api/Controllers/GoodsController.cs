﻿using Microsoft.AspNetCore.Mvc;

namespace MRP_Admin_Api.Controllers
{
    public class GoodsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
