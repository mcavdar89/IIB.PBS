using Core.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.Model.Dtos
{
    public class LoginDto:BaseDto
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
