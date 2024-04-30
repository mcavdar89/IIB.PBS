using Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.Model.Entities
{
    public class Nufus : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long TCKN { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
}
