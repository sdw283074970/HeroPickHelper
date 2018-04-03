using AutoMapper;
using HeroPickHelper.Dtos;
using HeroPickHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<HeroToclient, HeroDto>();
            Mapper.CreateMap<HeroDto, HeroToclient>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.DutyHeroes, opt => opt.Ignore());

            Mapper.CreateMap<Duty, DutyDto>();
            Mapper.CreateMap<DutyDto, Duty>();

            Mapper.CreateMap<DutyHeroDto, DutyHero>();
            Mapper.CreateMap<DutyHero, DutyHeroDto>()
                .ForMember(m => m.Duty, opt => opt.Ignore())
                .ForMember(m => m.Hero, opt => opt.Ignore());
        }
    }
}