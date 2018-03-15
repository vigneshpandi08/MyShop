using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepo
    {
         ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productcategories;

        public ProductCategoryRepo()
        {
            productcategories = cache["productcategories"] as List<ProductCategory>;
            if (productcategories == null)
            {
                productcategories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["products"] = productcategories;
        }
        public void Insert(ProductCategory p)
        {
            productcategories.Add(p);
        }
        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productcategories.Find(p => p.Id == productCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Category not Found");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory product = productcategories.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not Found");
            } 
        }
        public IQueryable<ProductCategory> Collection()
        {
            return productcategories.AsQueryable();
        }
        public void Delete(string Id)
        {
            ProductCategory productToDelete = productcategories.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                productcategories.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }
    }
}
