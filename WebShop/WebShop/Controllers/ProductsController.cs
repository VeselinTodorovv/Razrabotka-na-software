using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebShopApp.Core.Contracts;
using WebShopApp.Models.Products;
using WebShopApp.Models.Brands;
using WebShopApp.Models.Categories;
using WebShopApp.Infrastructure.Data.Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebShopApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public ProductsController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }

        // GET: ProductsController
        [AllowAnonymous]
        public ActionResult Index(string searchStringBrandName, string searchStringCategoryName)
        {
            var products = _productService.GetProducts(searchStringCategoryName, searchStringBrandName)
                .Select(p => new ProductIndexVm
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    BrandId = p.BrandId,
                    BrandName = p.Brand.BrandName,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.CategoryName,
                    Discount = p.Discount,
                    Picture = p.Picture,
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .ToList();
            
            return View(products);
        }

        /*public ActionResult FilterByBrand()
        {

        }*/

        // GET: ProductsController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductDetailsVm vm = new()
            { 
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                BrandName = product.Brand.BrandName,
                CategoryName = product.Category.CategoryName,
                Discount = product.Discount,
                Picture = product.Picture,
                Price = product.Price,
                Quantity = product.Quantity
            };

            return View(vm);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            var product = new ProductCreateVM
            {
                Brands = _brandService.GetBrands().Select(x => new BrandPairVM
                {
                    Id = x.Id,
                    Name = x.BrandName
                })
                .ToList(),

                Categories = _categoryService.GetCategories().Select(x => new CategoryPairVM
                {
                    Id = x.Id,
                    Name = x.CategoryName
                })
                .ToList()
            };

            return View(product);
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ProductCreateVM product)
        {
            if (ModelState.IsValid)
            {
                var createdId = _productService.Create(product.ProductName, product.BrandId,
                    product.CategoryId, product.Picture, product.Quantity, product.Price, product.Discount);

                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductEditVM viewModel = new()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount,

                Brands = _brandService.GetBrands().Select(x => new BrandPairVM
                {
                    Id = x.Id,
                    Name = x.BrandName
                })
                .ToList(),

                Categories = _categoryService.GetCategories().Select(x => new CategoryPairVM
                {
                    Id = x.Id,
                    Name = x.CategoryName
                })
                .ToList()
            };

            return View(viewModel);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditVM vm)
        {
            if (ModelState.IsValid)
            {
                var updated = _productService.Update(vm.Id, vm.ProductName, vm.BrandId, vm.CategoryId,
                    vm.Picture, vm.Quantity, vm.Price, vm.Discount);

                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(vm);
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductDeleteVm productDeleteVM = new()
            {
                Id = product.Id,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount
            };

            return View(productDeleteVM);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _productService.RemoveById(id);
            if (deleted)
            {
                return RedirectToAction("Success");
            }

            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
