﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Product : BaseEntity
    {
        // We can delete the Id property because now the BaseEntity
        // handles the Id. The constructor as well.
        //public string Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, 1000)]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }

        public string Image { get; set; }

        public byte[] Img { get; set; }

        //public Product()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
