using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.Models;
using System.Runtime.Caching;

namespace Shop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        // Save the list into the cache
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        // Return one product in the list
        public ProductCategory Find(string Id)
        {
            ProductCategory categoryToFind = productCategories.Find(p => p.Id == Id);

            if (categoryToFind != null)
            {
                return categoryToFind;
            }
            else
            {
                throw new Exception("Category not found!");
            }
        }

        // Return all products in a IQueryable.
        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        // Inserts a product into the list
        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        // Update a product into the list
        public void Update(ProductCategory cat)
        {
            ProductCategory productToUpdate = productCategories.Find(p => p.Id == cat.Id);

            if (productToUpdate != null)
            {
                productToUpdate = cat;
            }
            else
            {
                throw new Exception("Category not found!");
            }
        }

        // Delete a product from the list
        public void Delete(string Id)
        {
            ProductCategory categoryToDelete = productCategories.Find(p => p.Id == Id);

            if (categoryToDelete != null)
            {
                productCategories.Remove(categoryToDelete);
            }
            else
            {
                throw new Exception("Category not found!");
            }
        }

    }
}
