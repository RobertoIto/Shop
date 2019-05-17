using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.SQL
{
    public class DataContext: DbContext
    {
        public DataContext() : base("DefaultConnection") {

            
        }

        // This tells the data context to work with these models into the database.
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Basket> Baskets { set; get; }
        public DbSet<BasketItem> BasketItems { set; get; }

    }
}
