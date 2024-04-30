using IIB.PBS.Model.Dtos;
using IIB.PBS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.BL.Abstracts
{
    public interface IPersonelServis
    {
        IEnumerable<PersonelDto> List();
        PersonelDto Get(int id);
        Nufus GetNufus(int id);
        Nufus KaydetNufus(Nufus item);
        PersonelDto Kaydet(PersonelDto personel);
        PersonelDto Guncelle(PersonelDto personel);
    }
}
