using ExternalModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRP_DAL;
using MRP_DAL.Repository;

namespace MRP_Admin_Api.Controllers
{
    [ApiController]

    [Route("api/admin/clients")]
    public class ClientController : Controller
    {
        private readonly ClientRepository _clientRepository;
        
        public ClientController(DbContextOptions<AppDbContext> db)
        {
            _clientRepository = new ClientRepository(db);
        }
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var client = await _clientRepository.Get(id);
            if (client == null) return NotFound("Клиент не найден");
            return Ok(client);
        }
    }
}
