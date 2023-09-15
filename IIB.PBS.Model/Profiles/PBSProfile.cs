using AutoMapper;
using IIB.PBS.Model.Dtos;
using IIB.PBS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.Model.Profiles
{
    public class PBSProfile : Profile
    {
        public PBSProfile()
        {
            CreateMap<Personel, PersonelDto>()
                .ForMember(dest => dest.UnvanAd, opt => opt.MapFrom(src => src.Unvan.Ad))
                .ForMember(dest => dest.Isim, opt => opt.MapFrom(src => $"{src.Ad} {src.Soyad}"))
                ;
            CreateMap<PersonelDto, Personel>();
        }
    }
}
