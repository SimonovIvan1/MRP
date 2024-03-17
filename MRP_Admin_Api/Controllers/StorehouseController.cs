using ExternalModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRP_DAL.Repository;
using MRP_DAL;

namespace MRP_Admin_Api.Controllers
{
    [ApiController]

    [Route("api/admin/storehouses")]
    public class StorehouseController : Controller
    {
        private readonly StorehouseRepository _repository;

        public StorehouseController(DbContextOptions<AppDbContext> db)
        {
            _repository = new StorehouseRepository(db);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var clients = await _repository.GetAll();
                if (clients == null) return NotFound("Склады пропали или их пока нет");
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{storehouseId}")]
        public async Task<IActionResult> Get(Guid clientId)
        {
            try
            {
                var client = await _repository.Get(clientId);
                if (client == null) return NotFound("Склад не найден");
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task Delete(Guid id) => await _repository.Delete(id);

        [HttpPost]
        public async Task<IActionResult> Create(StorehouseDto newStorehouse)
        {
            try
            {
                await _repository.Create(newStorehouse);
                return Ok("Склад создан");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
