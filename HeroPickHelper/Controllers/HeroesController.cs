using HeroPickHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroPickHelper.Controllers
{
    public class HeroesController : Controller
    {
        private ApplicationDbContext _context;

        public HeroesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Heroes
        public ActionResult Index()
        {
            var heroes = _context.Heroes.ToList();

            return View(heroes);
        }
    }
}