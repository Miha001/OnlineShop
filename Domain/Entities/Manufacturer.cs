using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Manufacturer
    {
        [Key]
        public int ManufactorId { get; set; }

        public string NameOfManufacturer { get; set; }
    }
}
