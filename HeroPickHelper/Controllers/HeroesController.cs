using HeroPickHelper.Models;
using HeroPickHelper.ViewModel;
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
            var viewModel = new HeroViewModel()
            {
                heroList = _context.Heroes.ToList(),
                helper = new Helper.HeroDutyHelper()
            };

            return View(viewModel);
        }
    }
}