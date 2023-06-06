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
            if (ModelState.IsValid) {
                string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Event eventForDb = new Event {
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

            return View();
        }
    }
}