﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WebShopApp.Infrastructure.Data.Domain;
using WebShopApp.Models.Clients;

namespace WebShopApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: ClientsController
        public async Task<IActionResult> Index()
        {
            var allUsers = _userManager.Users.Select(u => new ClientIndexVM
            {
                Id = u.Id,
                Address = u.Address,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
            })
                .ToList();

            var adminIds = (await _userManager.GetUsersInRoleAsync("Administrator")).Select(a => a.Id).ToList();

            foreach (var user in allUsers)
            {
                user.isAdmin = adminIds.Contains(user.Id);
            }

            var users = allUsers.Where(x => x.isAdmin == false).OrderBy(x => x.UserName).ToList();

            return View(users);
        }

        //GET
        public ActionResult Detele(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            ClientDeleteVM clientToDelete = new ClientDeleteVM
            {
                Address = user.Address,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
            };

            return View(clientToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ClientDeleteVM bindingModel)
        {
            string id = bindingModel.Id;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            IdentityResult result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return NotFound();
            }

            return RedirectToAction("Success");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
