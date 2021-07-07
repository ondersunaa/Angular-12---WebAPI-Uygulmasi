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
    public class Status : ControllerBase
    {
        private readonly IServiceGeneric<Statu> _statuServiceGeneric;

        public Status(IServiceGeneric<Statu> statuServiceGeneric)
        {
            _statuServiceGeneric = statuServiceGeneric;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStatus()
        {
            var status = await _statuServiceGeneric.GetAllAsync();
            return Ok(status);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatuById(int id)
        {
            var statu = await _statuServiceGeneric.GetByIdAsync(id);
            if (statu == null)
            {
                return NotFound();
            }

            return Ok(statu);
        }

        [HttpPost]
        public async Task<IActionResult> PostStatu(Statu statu)
        {
            await _statuServiceGeneric.AddAsync(statu);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _statuServiceGeneric.Remove(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Statu statu, int id)
        {
            try
            {
                _statuServiceGeneric.Update(statu, id);
                return Ok(statu);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
