using IIB.PBS.BL.Abstracts;
using IIB.PBS.DAL.Abstracts;
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
        public IEnumerable<Personel> List(string isim)
        {
           var list = _repository.List<Personel>(d=> d.Ad.Contains(isim));

            //list = list.Where(d => d.Ad.Contains(isim));



            return list.ToList();


        }


        public void PersonelEkle(Personel personel)
        {
            _repository.Add(personel);
            _repository.SaveAll();
        }



    }
}
