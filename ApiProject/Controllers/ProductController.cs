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
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/Shop
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAll();
        }

        // GET: api/Shop/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        // POST: api/Shop
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _productService.Create(product);
            return Ok(product);
        }

        // PUT: api/Shop/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (!_productService.GetAll().Any(e => e.Id == product.Id))
            {
                return NotFound();
            }
            _productService.Update(product);
            return Ok(product);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.DeleteById(id);
            return Ok(product);
        }
    }
}