using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KargoAPI.Api.Dtos;
using KargoAPI.Core.Models;

namespace KargoAPI.Api.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CargoInfo, CargoInfoDTO>();
            CreateMap<CargoInfoDTO, CargoInfo>();
            CreateMap<CargoStatus, CargoStatuDTO>();
            CreateMap<CargoInfo, CargoInfoAddDTO>();
            CreateMap<CargoInfoAddDTO, CargoInfo>();
            CreateMap<CargoInfo, CargoInfoUpdateDTO>();
            CreateMap<CargoInfoUpdateDTO, CargoInfo>();

        }
    }
}
