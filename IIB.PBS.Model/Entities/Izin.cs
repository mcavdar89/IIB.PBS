using Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.Model.Entities
{
    public class Izin : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int IzinTipId { get; set; }
        public DateTime BaslamaTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public int Sure { get; set; }
    }
}
