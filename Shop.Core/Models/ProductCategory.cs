﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        // We can delete the Id property because now the BaseEntity
        // handles the Id. The constructor as well.
        //public string Id { get; set; }

        [Required]
        public string Category { get; set; }

        //public ProductCategory()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
