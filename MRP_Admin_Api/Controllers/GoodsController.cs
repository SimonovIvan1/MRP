﻿using ExternalModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRP_DAL.Repository;
using MRP_DAL;

namespace MRP_Admin_Api.Controllers
{
    [ApiController]

    [Route("api/admin/goods")]
    public class GoodsController : Controller
    {
        private readonly GoodsRepository _repository;

        public GoodsController(DbContextOptions<AppDbContext> db)
        {
            _repository = new GoodsRepository(db);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var clients = await _repository.GetAll();
                if (clients == null) return NotFound("Товары пропали или их пока нет");
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{goodsId}")]
        public async Task<IActionResult> Get(Guid goodsId)
        {
            try
            {
                var client = await _repository.Get(goodsId);
                if (client == null) return NotFound("Клиент не найден");
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
        public async Task<IActionResult> Create(GoodsDto newGoods)
        {
            try
            {
                await _repository.Create(newGoods);
                return Ok("Клиент создан");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
