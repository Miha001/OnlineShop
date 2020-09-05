﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
