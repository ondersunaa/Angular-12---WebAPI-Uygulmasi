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
    public class Customers : ControllerBase
    {
        private readonly IServiceGeneric<Customer> _customerServiceGeneric;

        public Customers(IServiceGeneric<Customer> customerServiceGeneric)
        {
            _customerServiceGeneric = customerServiceGeneric;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerServiceGeneric.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerServiceGeneric.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(Customer customer)
        {
            await _customerServiceGeneric.AddAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerServiceGeneric.Remove(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Customer customer, int id)
        {
            try
            {
                _customerServiceGeneric.Update(customer, id);
                return Ok(customer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
