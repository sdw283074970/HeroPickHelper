using HeroPickHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Http;
using System.Net;

namespace HeroPickHelper.Helper
{
    public class HeroDutyHelper
    {
        private ApplicationDbContext _context;

        public HeroDutyHelper()
        {
            _context = new ApplicationDbContext();
        }

        //// Get hero's duties helper
        //public IEnumerable<Duty> GetHeroDuties(int id)
        //{
        //    var dutyList = new List<Duty>();

        //    var heroInDb = _context.Heroes.Include(c => c.DutyHeroes).SingleOrDefault(c => c.Id == id);

        //    if (heroInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    foreach (var heroDuty in heroInDb.DutyHeroes)
        //    {
        //        dutyList.Add(_context.Duties.Single(c => c.Id == heroDuty.DutyId));
        //    }

        //    return dutyList;
        //}

        // Get hero's duties 以string格式返回某一具体英雄Id拥有的职责名称
        public IEnumerable<string> GetHeroDutyies(int id)
        {
            //返回某一具体英雄Id拥有的dutyId列表
            var dutyNameList = _context.DutyHeroes
                .Include(c => c.Duty)
                .Where(c => c.HeroId == id)
                .Select(c => c.Duty.Name);

            return dutyNameList;
        }
    }
}