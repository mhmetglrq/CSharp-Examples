﻿using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly MovieContext _context;
        public HomeController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                PopularMovies = _context.Movies.ToList()
            };
            
            return View(model);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
