using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KargoAPI.Core.Models;
using KargoAPI.Core.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace KargoAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly IServiceGeneric<Product> _productServiceGeneric;

        public Products(IServiceGeneric<Product> productServiceGeneric)
        {
            _productServiceGeneric = productServiceGeneric;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productServiceGeneric.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productServiceGeneric.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {
            await _productServiceGeneric.AddAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productServiceGeneric.Remove(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public  IActionResult Update(Product product,int id)
        {
            try
            {
                _productServiceGeneric.Update(product, id);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
    }
}
