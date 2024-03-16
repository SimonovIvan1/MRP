using Microsoft.AspNetCore.Mvc;

namespace MRP_Admin_Api.Controllers
{
    public class StorehouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
