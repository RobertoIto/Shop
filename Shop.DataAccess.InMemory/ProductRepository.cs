using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Shop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        // Save the list into the cache
        public void Commit()
        {
            cache["products"] = products;
        }

        // Return one product in the list
        public Product Find(string Id)
        {
            Product productToFind = products.Find(p => p.Id == Id);

            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }

        // Return all products in a IQueryable.
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        // Inserts a product into the list
        public void Insert(Product p)
        {
            products.Add(p);
        }

        // Update a product into the list
        public void Update(Product prod)
        {
            Product productToUpdate = products.Find(p => p.Id == prod.Id);

            if (productToUpdate != null)
            {
                productToUpdate = prod;
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }

        // Delete a product from the list
        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }


    }
}
