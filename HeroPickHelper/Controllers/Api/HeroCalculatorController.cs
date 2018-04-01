using HeroPickHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;

namespace HeroPickHelper.Controllers.Api
{
    public class HeroCalculatorController : ApiController
    {
        public ApplicationDbContext _context;

        public HeroCalculatorController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/herocalculater
        [HttpPost]
        public IHttpActionResult GetCalculateResult(int[] ids)
        {
            //查找HeroDuty列表中含有DutyId为1的对象(这个对象包含了英雄Id的信息)
            var carriesInfo = GetDutyInfo(1);
            var midsInfo = GetDutyInfo(2);
            var offlanesInfo = GetDutyInfo(3);
            var roamAndJunglesInfo = GetDutyInfo(4);
            var supportsInfo = GetDutyInfo(5);

            //返回这个计算结果列表给前端
            var resultList = new ResultList()
            {
                Carries = carriesInfo,
                Mids = midsInfo,
                RoamOrJuggles = roamAndJunglesInfo,
                Offlanes = offlanesInfo,
                Supports =supportsInfo
            };

            return Created(Request.RequestUri + "/" + "TBD", resultList);
        }

        //将"查找HeroDuty列表中含有DutyId为1的对象(这个对象包含了英雄Id的信息)"这个过程封装成方法
        //有了英雄克制数据库后，在这个方法里面写算法
        //目前按照英雄Id顺序返回所有12345号位，有了克制数据库和算法后，将按照克制指数排序后再返回
        public IList<Hero> GetDutyInfo(int id)
        {
            return _context.DutyHeroes
                .Include(c => c.Hero)
                .Where(c => c.DutyId == id)
                .Select(c => c.Hero)
                .ToList();
        }

    }
}
