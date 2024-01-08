using System.Globalization;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebShopApp.Core.Contracts;
using WebShopApp.Infrastructure.Data.Domain;
using WebShopApp.Models.Orders;

namespace WebShopApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrdersController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        // GET: OrdersController
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var orders = _orderService.GetOrders()
                .Select(x => new OrderIndexVm
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM-yyyy hh:mm", CultureInfo.InvariantCulture),
                    User = x.User.UserName,
                    Discount = x.Discount,
                    Price = x.Price,
                    Picture = x.Product.Picture,
                    ProductId = x.ProductId,
                    Product = x.Product.ProductName,
                    Quantity = x.Quantity,
                    TotalPrice = x.TotalPrice
                })
                .ToList();

            return View(orders);
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
        public ActionResult Create(int id)
        {
            var product = _productService.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }

            OrderCreateVM order = new()
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Discount = product.Discount,
                Picture = product.Picture,
                Price = product.Price,
                Quantity = product.Quantity
            };

            return View(order);
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreateVM viewModel)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var product = _productService.GetProductById(viewModel.ProductId);
            if (product == null || currentUserId == null || product.Quantity < viewModel.Quantity || product.Quantity == 0)
            {
                return RedirectToAction("Denied", "Orders");
            }

            if (ModelState.IsValid)
            {
                _orderService.Create(viewModel.ProductId, currentUserId, viewModel.Quantity);
            }

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Denied()
        {
            return View();
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult MyOrders()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = _orderService.GetOrdersByUser(currentUserId)
                .Select(x => new OrderIndexVm
                {
                    Id = x.Id,
                    Discount = x.Discount,
                    OrderDate = x.OrderDate.ToString("dd-MMM-yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = currentUserId,
                    User = x.User.UserName,
                    ProductId = x.ProductId,
                    Product = x.Product.ProductName,
                    Picture = x.Product.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    TotalPrice = x.TotalPrice
                })
                .ToList();

            return View(orders);
        }
    }
}
