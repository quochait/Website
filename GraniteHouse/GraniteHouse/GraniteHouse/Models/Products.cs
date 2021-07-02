﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Models
{
    public class Products
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public bool Available { get; set; }

        public string Image { get; set; }

        public string ShadeColor { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeID { get; set; }

        [ForeignKey("ProductTypeID")]
        public virtual ProductTypes ProductTypes { get; set; }

        [Display(Name = "Special Tag")]
        public int SpecialTagID { get; set; }

        [ForeignKey("SpecialTagID")]
        public virtual SpecialTags SpecialTags { get; set; }
    }
}
