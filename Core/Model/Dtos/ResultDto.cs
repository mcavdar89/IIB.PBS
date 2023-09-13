using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.Dtos
{
    public class ResultDto : BaseDto
    {
        public bool Satatus { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }


    }
}
