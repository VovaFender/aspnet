using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using AutoMapper;
using MvcApplication1.Models;
using MvcApplication1.Models.ViewModels;

namespace MvcApplication1.Mappers
{
    public class CommonMapper : IMapper
    {

        static CommonMapper()
        {
            Mapper.CreateMap<user, ViewUser>()
                .ForMember(d => d.BirthDateDay, src => src.MapFrom(s => s.birth_date.Day))
                .ForMember(d => d.BirthDateMonth, src => src.MapFrom(s => s.birth_date.Month))
                .ForMember(d => d.BirthDateYear, src => src.MapFrom(s => s.birth_date.Year));
            Mapper.CreateMap<ViewUser, user>()
                .ForMember(d => d.id, s => s.Ignore())
                .ForMember(dest => dest.birth_date, 
                            opt => opt.MapFrom(src => new DateTime(src.BirthDateYear, src.BirthDateMonth, src.BirthDateDay)));
        }
        
        public object Map(object source, Type sourceType, Type destinationType)
        {            
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}