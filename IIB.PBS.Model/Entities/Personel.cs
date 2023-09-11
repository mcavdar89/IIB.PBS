using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.Model.Entities
{
    public class Personel:BaseEntity
    {
       
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string? Aciklama { get; set; }
    }
}
