using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.Model.Entities
{
    public class Unvan : BaseEntity
    {
        [Key]
        public short Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }

        public List<Personel> Personel { get; set; }

    }
}
