using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using ASPEventures.Data;
using ASPEventures.Domain;
using ASPEventures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPEventures.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult All()
        {
            var events = _context.Events
                .Select(eventFromDb => new EventAllViewModel {
                    Id = eventFromDb.Id,
                    Name = eventFromDb.Name,
                    Place = eventFromDb.Place,
                    Start = eventFromDb.Start.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    End = eventFromDb.End.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    Owner = eventFromDb.Owner.UserName
                }).ToList();
            
            return View(events);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventCreateBindingModel model)
        {
            if (!ModelState.IsValid) return View();
            
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var eventForDb = new Event {
                Name = model.Name,
                Place = model.Place,
                Start = model.Start,
                End = model.End,
                TotalTickets = model.TotalTickets,
                TicketPrice = model.TicketPrice,
                OwnerId = currentUserId
            };

            _context.Events.Add(eventForDb);
            _context.SaveChanges();

            return RedirectToAction("All");
        }

        [Authorize]
        public IActionResult My(string searchString) {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null) {
                return null;
            }

            List<OrderListingViewModel> orders = _context.Orders
                .Where(o => o.CustomerId == user.Id)
                .Select(o => new OrderListingViewModel {
                    Id = o.Id,
                    EventId = o.EventId,
                    EventName = o.Event.Name,
                    EventStart = o.Event.Start.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                    EventEnd = o.Event.End.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                    EventPlace = o.Event.Place,
                    OrderedOn = o.OrderedOn.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                    CustomerId = o.CustomerId,
                    CustomerUsername = o.Customer.UserName,
                    TicketsCount = o.TicketsCount
                })
                .ToList();

            if (!string.IsNullOrEmpty(searchString)) {
                orders = orders.Where(o => o.EventPlace.Contains(searchString)).ToList();
            }

            return View(orders);
        }
    }
}