using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KargoAPI.Api.Dtos;
using KargoAPI.Core.Models;
using KargoAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace KargoAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoInfos : ControllerBase
    {
        private readonly IServiceGeneric<CargoInfo> _cargoInfoService;
        private readonly IServiceGeneric<CargoProduct> _cargoproductService;
        private readonly IServiceGeneric<Product> _productService;
        private readonly IServiceGeneric<Customer> _customerService;
        private readonly IServiceGeneric<CargoStatus> _cargoStatusService;
        private readonly IServiceGeneric<Statu> _statuService;
        private readonly IMapper _mapper;
        public CargoInfos(IServiceGeneric<CargoInfo> serviceGeneric, IServiceGeneric<Product> productService, IServiceGeneric<Customer> customerService,
            IServiceGeneric<CargoStatus> cargoStatusService, IMapper mapper, IServiceGeneric<CargoProduct> cargoproductService, IServiceGeneric<Statu> statuService)
        {
            _cargoInfoService = serviceGeneric;
            _productService = productService;
            _customerService = customerService;
            _cargoStatusService = cargoStatusService;
            _mapper = mapper;
            _cargoproductService = cargoproductService;
            _statuService = statuService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCargo()
        {
            int i = 0, y = 0, z = 0;
            var cargoInfos = await _cargoInfoService.GetAllAsync();
            var cargoInfosDto = _mapper.Map<IEnumerable<CargoInfoDTO>>(cargoInfos);
            if (cargoInfos.Count() < 0)
            {
                return NotFound("Sisteme kayıtlı kargo yok.");
            }

            try
            {
                foreach (var rowCargoInfo in cargoInfosDto)
                {
                    i = 0;
                    y = 0;
                    z = 0;
                    var cargoStatus = await _cargoStatusService.Where(x => x.CargoNumber == rowCargoInfo.CargoNumber);
                    var cargoStatusDto = _mapper.Map<IEnumerable<CargoStatuDTO>>(cargoStatus);
                    foreach (var rowStatuDto in cargoStatus)
                    {
                        cargoStatusDto.ToList()[z].StatuName =
                            _statuService.GetByIdAsync(rowStatuDto.StatuId).Result.Name;
                        z++;
                    }
                    var cargoProduct = await _cargoproductService.Where(x => x.CargoNumber == rowCargoInfo.CargoNumber);
                    if (cargoProduct.Count() > 0)
                    {
                        List<Product> products = new List<Product>(cargoProduct.Count());
                        foreach (var rowProduct in cargoProduct)
                        {
                            var product = await _productService.GetByIdAsync(rowProduct.ProductId);
                            products.Add(product);
                        }
                        rowCargoInfo.Products = products;
                    }
                    if (cargoStatus.Count() > 0)
                    {
                        rowCargoInfo.CargoStatuses = cargoStatusDto.ToList();

                    }

                    rowCargoInfo.Customer = await _customerService.GetByIdAsync(cargoInfos.ToList()[y].CustomerId);
                    y++;

                    rowCargoInfo.CurrentStatu = _statuService.GetByIdAsync(cargoInfos.ToList()[i].CurrentStatu).Result.Name;
                    i++;
                }

                return Ok(cargoInfosDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("{cargoNumber}")]
        public async Task<IActionResult> GetByCargoNumber(string cargoNumber)
        {
            int i = 0;
            try
            {
                var cargoInfo = _cargoInfoService.Where(x => x.CargoNumber == cargoNumber).Result.SingleOrDefault();
                if (cargoInfo == null)
                {
                    return BadRequest("Kargo numarası bulunamadı.");
                }
                var cargoInfoDto = _mapper.Map<CargoInfoDTO>(cargoInfo);
                var cargoStatus = await _cargoStatusService.Where(x => x.CargoNumber == cargoInfo.CargoNumber);
                var cargoStatuDto = _mapper.Map<IEnumerable<CargoStatuDTO>>(cargoStatus);
                if (cargoStatus.Count() > 0)
                {
                    foreach (var rowStatuDto in cargoStatus)
                    {
                        cargoStatuDto.ToList()[i].StatuName = _statuService.GetByIdAsync(rowStatuDto.StatuId).Result.Name;
                        i++;
                    }
                }
                var cargoProduct = await _cargoproductService.Where(x => x.CargoNumber == cargoInfo.CargoNumber);
                if (cargoProduct.Count() > 0)
                {
                    List<Product> products = new List<Product>(cargoProduct.Count());
                    foreach (var rowProduct in cargoProduct)
                    {
                        var product = await _productService.GetByIdAsync(rowProduct.ProductId);
                        products.Add(product);
                    }
                    cargoInfoDto.Products = products;
                }
                cargoInfoDto.Customer = await _customerService.GetByIdAsync(cargoInfo.CustomerId);
                cargoInfoDto.CurrentStatu = _statuService.GetByIdAsync(cargoInfo.CurrentStatu).Result.Name;
                cargoInfoDto.CargoStatuses = cargoStatuDto.ToList();
                return Ok(cargoInfoDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostCargoInfo([FromBody] CargoInfoAddDTO cargoInfoDto)
        {
            CargoStatus cargoStatu = new CargoStatus();
            cargoStatu.CargoNumber = cargoInfoDto.CargoNumber;
            cargoStatu.StatuId = cargoInfoDto.CurrentStatu;
            cargoStatu.ChangeStatuDate = DateTime.Now;
            cargoStatu.Description = cargoInfoDto.Description;
            await _cargoStatusService.AddAsync(cargoStatu);
            try
            {
                var cargoInfo = _mapper.Map<CargoInfo>(cargoInfoDto);
                await _cargoInfoService.AddAsync(cargoInfo);


                if (cargoInfoDto.Products.Count > 0)
                {
                    foreach (var row in cargoInfoDto.Products)
                    {
                        CargoProduct model = new CargoProduct();
                        model.CargoNumber = cargoInfoDto.CargoNumber;
                        model.ProductId = row.Id;
                        await _cargoproductService.AddAsync(model);
                    }
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CargoInfoUpdateDTO cargoInfoUpdateDto, int id)
        {
            try
            {
                var cargoInfo = _mapper.Map<CargoInfo>(cargoInfoUpdateDto);
                var cargo = _cargoInfoService.GetByIdAsync(id);
                if (cargo.Result.CurrentStatu != cargoInfoUpdateDto.CurrentStatu)
                {
                    CargoStatus cargoStatu = new CargoStatus();
                    cargoStatu.CargoNumber = cargoInfoUpdateDto.CargoNumber;
                    cargoStatu.StatuId = cargoInfoUpdateDto.CurrentStatu;
                    cargoStatu.ChangeStatuDate = DateTime.Now;
                    cargoStatu.Description = cargoInfoUpdateDto.Description;
                    await _cargoStatusService.AddAsync(cargoStatu);
                }
                _cargoInfoService.Update(cargoInfo, id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cargoInfoService.Remove(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
