using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using AutoMapper;
using MvcApplication1.Models;
using MvcApplication1.Models.ViewModels;
using User = MvcApplication1.Models.User;

namespace MvcApplication1.Mappers
{
    public class CommonMapper : IMapper
    {

        static CommonMapper()
        {            
            Mapper.CreateMap<User, ViewUser>()
                .ForMember(d => d.BirthDateDay, src => src.MapFrom(s => s.BirthDate.Value.Day ))
                .ForMember(d => d.BirthDateMonth, src => src.MapFrom(s => s.BirthDate.Value.Month ))
                .ForMember(d => d.BirthDateYear, src => src.MapFrom(s => s.BirthDate.Value.Year));

            Mapper.CreateMap<ViewUser, User>()
                .ForMember(d => d.ID, s => s.Ignore())
                .ForMember(dest => dest.BirthDate, 
                            opt => opt.MapFrom(src => new DateTime(src.BirthDateYear, src.BirthDateMonth, src.BirthDateDay)));
        }
        
        public object Map(object source, Type sourceType, Type destinationType)
        {            
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}