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
        public PersonelServis(IPBSRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<PersonelDto> List(string isim)
        {
           //var list = _repository.List<Personel>(d=> d.Ad.Contains(isim));

            //list = list.Where(d => d.Ad.Contains(isim));

            //var list = _repository.ListProject<Personel, PersonelDto>(d => d.Ad.Contains(isim));

            var list = _repository.ListFromSql<PersonelDto>(@$"select p.*,u.Ad UnvanAd 
                                                                  from Personel p
                                                                  left join Unvan u on u.Id = p.UnvanId");

            return list;


        }


        public void PersonelEkle(Personel personel)
        {
            _repository.Add(personel);
            _repository.SaveAll();
        }



    }
}
