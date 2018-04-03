using HeroPickHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using HeroPickHelper.Helper;

namespace HeroPickHelper.Controllers.Api
{
    public class HeroCalculatorController : ApiController
    {
        public ApplicationDbContext _context;

        public HeroCalculatorController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/herocalculator
        //public IHttpActionResult GetResult()
        //{
        //    //查找HeroDuty列表中含有DutyId为1的对象(这个对象包含了英雄Id的信息)
        //    var carriesInfo = GetDutyInfo(1);
        //    var midsInfo = GetDutyInfo(2);
        //    var offlanesInfo = GetDutyInfo(3);
        //    var roamAndJunglesInfo = GetDutyInfo(4);
        //    var supportsInfo = GetDutyInfo(5);

        //    //返回这个计算结果列表给前端
        //    var resultList = new ResultList()
        //    {
        //        Carries = carriesInfo,
        //        Mids = midsInfo,
        //        RoamOrJuggles = roamAndJunglesInfo,
        //        Offlanes = offlanesInfo,
        //        Supports = supportsInfo
        //    };

        //    return Ok(resultList);
        //}


        //POST /api/herocalculator
        [HttpPost]
        public IHttpActionResult GetCalculateResult(int[] enemyIds)
        {
            ////查找HeroDuty列表中含有DutyId为1/2/3/4/5的对象(这个对象包含了英雄Id的信息)
            //var carriesInfo = GetDutyInfo(1);
            //var midsInfo = GetDutyInfo(2);
            //var offlanesInfo = GetDutyInfo(3);
            //var roamAndJunglesInfo = GetDutyInfo(4);
            //var supportsInfo = GetDutyInfo(5);

            ////返回这个计算结果列表给前端
            //var resultList = new ResultList()
            //{
            //    Carries = carriesInfo,
            //    Mids = midsInfo,
            //    RoamOrJuggles = roamAndJunglesInfo,
            //    Offlanes = offlanesInfo,
            //    Supports =supportsInfo
            //};

            var helper = new HeroDutyHelper();

            if (enemyIds == null)
            {
                return BadRequest();
            }

            if (enemyIds.Count() == 1)
            {
                var enemyCounteredHeroList = helper.GetEnemyCounteredHeroList(enemyIds[0]);
                var weightedList = helper.GetWeightedList(enemyCounteredHeroList, enemyIds[0]);

                var orderedList = helper.OrderList(weightedList);

                var carriesInfo = helper.GetDutyInfo(1, orderedList);
                var midsInfo = helper.GetDutyInfo(2, orderedList);
                var offlanesInfo = helper.GetDutyInfo(3, orderedList);
                var roamAndJunglesInfo = helper.GetDutyInfo(4, orderedList);
                var supportsInfo = helper.GetDutyInfo(5, orderedList);

                //返回这个计算结果列表给前端
                var resultList = new ResultList()
                {
                    Carries = carriesInfo,
                    Mids = midsInfo,
                    RoamOrJuggles = roamAndJunglesInfo,
                    Offlanes = offlanesInfo,
                    Supports = supportsInfo
                };

                return Ok(resultList);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
