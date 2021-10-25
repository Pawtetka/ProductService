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
    public class StorageController : ControllerBase
    {
        private IStorageService _storageService;
        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        // GET: api/Shop
        [HttpGet]
        public IEnumerable<Storage> Get()
        {
            return _storageService.GetAll();
        }

        // GET: api/Shop/5
        [HttpGet("{id}")]
        public ActionResult<Storage> Get(int id)
        {
            var storage = _storageService.GetById(id);
            if (storage == null)
            {
                return NotFound();
            }
            return new ObjectResult(storage);
        }

        // POST: api/Shop
        [HttpPost]
        public ActionResult<Shop> Post([FromBody] Storage storage)
        {
            if (storage == null)
            {
                return BadRequest();
            }
            _storageService.Create(storage);
            return Ok(storage);
        }

        // PUT: api/Shop/5
        [HttpPut("{id}")]
        public ActionResult<Storage> Put([FromBody] Storage storage)
        {
            if (storage == null)
            {
                return BadRequest();
            }
            if (!_storageService.GetAll().Any(e => e.Id == storage.Id))
            {
                return NotFound();
            }
            _storageService.Update(storage);
            return Ok(storage);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Shop> Delete(int id)
        {
            var shop = _storageService.GetById(id);
            if (shop == null)
            {
                return NotFound();
            }
            _storageService.DeleteById(id);
            return Ok(shop);
        }
    }
}