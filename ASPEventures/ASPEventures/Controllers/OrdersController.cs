using System;
using System.Linq;
using System.Security.Claims;
using ASPEventures.Data;
using ASPEventures.Domain;
using ASPEventures.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPEventures.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Create(OrderCreateBindingModel bindingModel) {
            if (ModelState.IsValid) {
                string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var user = _context.Users.SingleOrDefault(u => u.Id == currentUserId);
                var ev = _context.Events.SingleOrDefault(e => e.Id == bindingModel.EventId);

                if (user == null || ev == null || ev.TotalTickets < bindingModel.TicketsCount) {
                    return RedirectToAction("All", "Events");
                }
                
                var orderFromDb = new Order {
                    OrderedOn = DateTime.UtcNow,
                    EventId = bindingModel.EventId,
                    TicketsCount = bindingModel.TicketsCount,
                    CustomerId = currentUserId
                };

                ev.TotalTickets -= bindingModel.TicketsCount;

                _context.Events.Update(ev);
                _context.Orders.Add(orderFromDb);
                _context.SaveChanges();
            }

            return RedirectToAction("All", "Events");
        }
    }
}