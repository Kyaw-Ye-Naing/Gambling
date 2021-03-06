﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Gambling_Proj.Models;
using Microsoft.VisualStudio.Web.CodeGeneration;


namespace Gambling_Proj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Gambling_AppContext db = new Gambling_AppContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var user=HttpContext.Session.GetString("Username");
            ViewBag.UserName = user;
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(TblUser model)
        {
            if (ModelState.IsValid)
            {
               
                    var v = db.TblUser.Where(a => a.Username.Equals(model.Username) && a.Password.Equals(model.Password)).FirstOrDefault();
                    if (v != null)
                    {
                    var loc = db.TblUser.Where(a => a.Username == v.Username).First().Lock;
                   if (loc == true)
                      {
                           TempData["Lock"] = "Your Account is Locked!";
                            return View("LogIn", model);
                       }
                      else
                       {
                       
                        //save user information in session
                        HttpContext.Session.SetString("Username", v.Username);
                        return RedirectToAction("Index");
                    }
                    // HttpCookie login = new HttpCookie("login");
                    // Response.Cookies["login"]["Id"] = v.Id.ToString();
                    // Response.Cookies["login"]["Name"] = v.Name.ToString();
                    // Response.Cookies["login"]["UserType"] = hh.UserTypes.Where(a => a.Id == v.UserTypeId).First().Name;
                    // login.Expires = DateTime.Now.AddSeconds(30);
                    // Response.Cookies.Add(login);
                
                    }
                    else
                    {
                    TempData["Error"] = "Something went wrong! Username or Password is incoorect";
                        return View("LogIn", model);
                    }
                
            }
            return View(model);
        }

            public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
