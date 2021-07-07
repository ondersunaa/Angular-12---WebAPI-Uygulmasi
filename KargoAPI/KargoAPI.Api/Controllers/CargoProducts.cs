using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KargoAPI.Core.Models;
using KargoAPI.Core.Services;

namespace KargoAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoProducts : ControllerBase
    {
        private readonly IServiceGeneric<CargoProduct> _productServiceGeneric;
        private readonly IServiceGeneric<Product> _productServic;

        public CargoProducts(IServiceGeneric<CargoProduct> productServiceGeneric, IServiceGeneric<Product> productServic)
        {
            _productServiceGeneric = productServiceGeneric;
            _productServic = productServic;
        }
        [HttpGet("{cargoNumber}")]
        public async Task<IActionResult> GetAllProducts(string cargoNumber)
        {
            var cargoProducts = await _productServiceGeneric.Where(x => x.CargoNumber == cargoNumber);
            List<Product> products = new List<Product>(cargoProducts.Count());
            foreach (var row in cargoProducts)
            {
                var product = await _productServic.GetByIdAsync(row.ProductId);
                products.Add(product);
            }
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(CargoProduct product)
        {
            var cargoProduct = _productServic.GetByIdAsync(product.ProductId);
            var cargoNumber = _productServiceGeneric.Where(x=>x.CargoNumber == product.CargoNumber).Result.SingleOrDefault();
            if (cargoNumber == null || cargoProduct == null)
            {
                return BadRequest();
            }
            await _productServiceGeneric.AddAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productServiceGeneric.Remove(id);
            return NoContent();
        }

    }
}
