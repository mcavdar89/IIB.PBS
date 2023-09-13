using Core.Model.Dtos;
using IIB.PBS.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.BL.Abstracts
{
    public interface IAccountServis
    {
        ResultDto Login(LoginDto loginDto);
    }
}
