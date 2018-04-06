using HeroPickHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HeroPickHelper.Controllers.Api
{
    public class HeroColoredController : ApiController
    {
        private ApplicationDbContext _context;

        public HeroColoredController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/herocolored
        public IHttpActionResult GetColoredHeroes()
        {
            var result = new ColoredHeroGroup();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            result.Purple = GetColoredGroup(1);
            result.Red = GetColoredGroup(2);
            result.Blue = GetColoredGroup(3);
            result.Yellow = GetColoredGroup(4);
            result.Green = GetColoredGroup(5);
            result.White = GetColoredGroup(6);

            return Ok(result);
        }

        public IList<Hero> GetColoredGroup(int id)
        {
            return _context.Heroes.Where(c => c.ColorId == id).ToList();
        }
    }
}
