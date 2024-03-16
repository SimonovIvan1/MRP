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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var clients = await _clientRepository.GetAll();
                if (clients == null) return NotFound("Клиенты пропали или их пока нет");
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/{clientId}")]
        public async Task<IActionResult> Get(Guid clientId)
        {
            try
            {
                var client = await _clientRepository.Get(clientId);
                if (client == null) return NotFound("Клиент не найден");
                return Ok(client);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task Delete(Guid id) => await _clientRepository.Delete(id);

        [HttpPost]
        public async Task<IActionResult> Create(ClientDto newClient)
        {
            try
            {
                await _clientRepository.Create(newClient);
                return Ok("Клиент создан");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
