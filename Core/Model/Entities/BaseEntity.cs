using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.Entities
{
    public abstract class BaseEntity
    {

        [Key]
        public object Id { get; set; }
    }
}
