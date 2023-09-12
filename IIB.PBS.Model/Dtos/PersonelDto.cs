using Core.Model.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.Model.Dtos
{
    public class PersonelDto : BaseDto
    {
        public int Id { get; set; }
        public short UnvanId { get; set; }
        public string UnvanAd { get; set; }
        public string Isim { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string? Aciklama { get; set; }
    }
}
