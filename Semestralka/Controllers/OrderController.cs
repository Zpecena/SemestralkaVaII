using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Semestralka.Areas.Identity.Data;
using Semestralka.Data;
using Semestralka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semestralka.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<SemestralkaUser> userManager;
        private readonly SemestralkaDbContext _db;

        public OrderController(UserManager<SemestralkaUser> userManager, SemestralkaDbContext db)
        {
            this.userManager = userManager;
            this._db = db;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Show()
        {
            IEnumerable<Order> objList = _db.Orders;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(order);

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Orders.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Show");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Change(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Orders.Find(id);
            return View(obj);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Change(Order obj)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Show");
            }
            return View(obj);
        }
    }
}
