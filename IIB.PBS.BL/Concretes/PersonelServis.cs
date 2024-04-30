using AutoMapper;
using IIB.PBS.BL.Abstracts;
using IIB.PBS.DAL.Abstracts;
using IIB.PBS.Model.Dtos;
using IIB.PBS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.BL.Concretes
{
    public class PersonelServis : IPersonelServis
    {
        private readonly IPBSRepository _repository;
        private readonly IMapper _mapper;
        public PersonelServis(IPBSRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<PersonelDto> List(string isim)
        {
           //var list = _repository.List<Personel>(d=> d.Ad.Contains(isim));

            //list = list.Where(d => d.Ad.Contains(isim));

            var list = _repository.ListProject<Personel, PersonelDto>(d=>1==1);

            //var list = _repository.ListFromSql<PersonelDto>(@$"select p.*,u.Ad UnvanAd 
            //                                                      from Personel p
            //                                                      left join Unvan u on u.Id = p.UnvanId");

            return list;


        }


        public PersonelDto Guncelle(PersonelDto personel)
        {
            var data = _mapper.Map<Personel>(personel);
            _repository.Update(data);
            _repository.SaveAll();
            return _mapper.Map<PersonelDto>(data);
        }


        public PersonelDto Kaydet(PersonelDto personel)
        {
            var data = _mapper.Map<Personel>(personel);
            _repository.Add(data);
            _repository.SaveAll();
            return _mapper.Map<PersonelDto>(data);
        }



    }
}
