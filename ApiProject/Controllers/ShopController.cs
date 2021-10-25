using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProject.Business.Services.Interfaces;
using ApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        // GET: api/Shop
        [HttpGet]
        public IEnumerable<Shop> Get()
        {
            return _shopService.GetAll();
        }

        // GET: api/Shop/5
        [HttpGet("{id}")]
        public ActionResult<Shop> Get(int id)
        {
            var shop = _shopService.GetById(id);
            if (shop == null)
            {
                return NotFound();
            }
            return new ObjectResult(shop);
        }

        // POST: api/Shop
        [HttpPost]
        public ActionResult<Shop> Post([FromBody] Shop shop)
        {
            if (shop == null)
            {
                return BadRequest();
            }
            _shopService.Create(shop);
            return Ok(shop);
        }

        // PUT: api/Shop/5
        [HttpPut("{id}")]
        public ActionResult<Shop> Put([FromBody] Shop shop)
        {
            if (shop == null)
            {
                return BadRequest();
            }
            if (!_shopService.GetAll().Any(e => e.Id == shop.Id))
            {
                return NotFound();
            }
            _shopService.Update(shop);
            return Ok(shop);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Shop> Delete(int id)
        {
            var shop = _shopService.GetById(id);
            if (shop == null)
            {
                return NotFound();
            }
            _shopService.DeleteById(id);
            return Ok(shop);
        }
    }
}
