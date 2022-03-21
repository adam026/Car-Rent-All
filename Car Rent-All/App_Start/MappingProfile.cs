using AutoMapper;
using Car_Rent_All.DTOS;
using Car_Rent_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rent_All.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Ugyfel, UgyfelDTO>();
            Mapper.CreateMap<UgyfelDTO, Ugyfel>();
            Mapper.CreateMap<Jarmu, JarmuDTO>();
            Mapper.CreateMap<JarmuDTO, Jarmu>();
            Mapper.CreateMap<Valto, ValtoDTO>();
            Mapper.CreateMap<ValtoDTO, Valto>();
            Mapper.CreateMap<UzemanyagDTO, Uzemanyag>();
            Mapper.CreateMap<Uzemanyag, UzemanyagDTO>();
        }

    }
}