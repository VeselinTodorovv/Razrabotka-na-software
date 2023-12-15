using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebShop.Infrastructure.Data;

using WebShopApp.Core.Contracts;
using WebShopApp.Infrastructure.Data.Domain;

namespace WebShopApp.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount)
        {
            Product product = new Product
            {
                ProductName = name,
                Brand = _context.Brands.Find(brandId),
                Category = _context.Categories.Find(categoryId),

                Picture = picture,
                Quantity = quantity,
                Price = price,
                Discount = discount
            };

            _context.Products.Add(product);
            return _context.SaveChanges() != 0;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName)
        {
            var products = _context.Products.ToList();

            if (!string.IsNullOrEmpty(searchStringBrandName) && !string.IsNullOrEmpty(searchStringCategoryName))
            {
                products = products.Where(x => x.Brand.BrandName.ToLower().Contains(searchStringBrandName)
                && x.Category.CategoryName.ToLower().Contains(searchStringCategoryName))
                    .ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringBrandName))
            {
                products = products.Where(x => x.Brand.BrandName.ToLower().Contains(searchStringBrandName)).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringCategoryName))
            {
                products = products.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName)).ToList();
            }

            return products;
        }

        public bool RemoveById(int productId)
        {
            Product product = _context.Products.Find(productId);
            if (product == default(Product))
            {
                return false;
            }

            _context.Remove(product);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int productId, string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount)
        {
            //TODO: get product, don't create new one
            Product product = new Product
            {
                Id = productId,
                ProductName = name,
                Brand = _context.Brands.Find(brandId),
                Category = _context.Categories.Find(categoryId),

                Picture = picture,
                Quantity = quantity,
                Price = price,
                Discount = discount
            };

            _context.Products.Update(product);
            return _context.SaveChanges() != 0;
        }
    }
}
