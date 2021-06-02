using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyConverter.Api.Data.Entities;
using CurrencyConverter.Api.Models;

namespace CurrencyConverter.Api
{
    public class CurrencyMappingProfile : Profile
    {
        public CurrencyMappingProfile()
        {
            CreateMap<Currency, CurrencyViewModel>()
                .ForMember(c => c.Name, opts => opts.MapFrom(s => s.Name))
                .ForMember(c => c.CurrencyCode, opts => opts.MapFrom(s => s.CurrencyCode))
                .ForMember(c => c.Symbol, opts => opts.MapFrom(s => s.Symbol))

                .ReverseMap();

        }
    }
}
