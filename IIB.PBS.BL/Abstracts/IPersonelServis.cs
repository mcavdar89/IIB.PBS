﻿using IIB.PBS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.BL.Abstracts
{
    public interface IPersonelServis
    {
        IEnumerable<Personel> List(string isim);
        
    }
}
