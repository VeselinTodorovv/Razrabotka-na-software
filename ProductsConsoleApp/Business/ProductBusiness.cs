using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;

namespace Business
{
    public class ProductBusiness
    {
        private ProductContext _productContext;

        public List<Product> GetAll() {
            using (_productContext = new ProductContext()) {
                return _productContext.Products.ToList();
            }
        }

        public Product Get(int id) {
            using (_productContext = new ProductContext()) {
                return _productContext.Products.Find(id);
            }
        }

        public void Add(Product product) {
            using (_productContext = new ProductContext()) {
                _productContext.Products.Add(product);
                _productContext.SaveChanges();
            }
        }

        public void Update(Product product) {
            using (_productContext = new ProductContext()) {
                _productContext.Products.Update(product);
                _productContext.SaveChanges();
            }
        }

        public void Delete(int id) {
            using (_productContext = new ProductContext()) {
                var product = _productContext.Products.Find(id);
                if (product != null) {
                    _productContext.Products.Remove(product);
                    _productContext.SaveChanges();
                }
            }
        }

    }
}