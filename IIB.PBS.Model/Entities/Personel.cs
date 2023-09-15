using Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.Model.Entities
{
    [Table("Personel")]
    public class Personel:BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public short UnvanId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tel { get; set; }
        public string? Aciklama { get; set; }


        [ForeignKey("UnvanId")]
        public virtual Unvan Unvan { get; set; }
    }
}
