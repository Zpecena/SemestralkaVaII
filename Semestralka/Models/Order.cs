﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Semestralka.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Description { get; set; }
        public string State { get; set; }

    }
}
