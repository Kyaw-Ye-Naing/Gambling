using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gambling_Proj.Controllers
{
    public class UsersGamRController : Controller
    {
        // GET: UsersGamRController
        public IActionResult Index()
        {

            return View();
        }

        // GET: UsersGamRController/Details/5
        public IActionResult View(int id)
        {
            return View();
        }

        // GET: UsersGamRController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersGamRController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsersGamRController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersGamRController/Edit/5
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

        // GET: UsersGamRController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersGamRController/Delete/5
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
    }
}
