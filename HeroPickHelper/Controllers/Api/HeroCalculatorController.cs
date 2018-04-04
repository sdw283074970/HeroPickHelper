﻿using HeroPickHelper.Models;
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
            //实例化helper对象，该函数封装了核心算法和各种辅助函数
            var helper = new HeroDutyHelper();

            //如果ModeState没被验证，则返回BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //如果收到的json数据包为空，则返回BadRequest
            if (enemyIds == null || enemyIds.Count() > 5)
            {
                return BadRequest();
            }

            //如果json数组中只有一个元素(英雄)，则省略合并步骤
            if (enemyIds.Count() == 1)
            {
                var enemyCounteredHeroList = helper.GetEnemyCounteredHeroList(enemyIds[0]);
                var weightedList = helper.GetWeightedList(enemyCounteredHeroList, enemyIds[0]);

                var resultList = helper.GetCalculateResult(weightedList);

                return Created(Request.RequestUri + "/" + enemyIds[0],resultList);
            }
            else        //否则，调用封装在helper对象中的合并列表函数
            {
                var weightedList = new List<HeroCounter>();
                for (int i = 0; i < enemyIds.Count(); i++)
                {
                    var enemyCounteredHeroList = helper.GetEnemyCounteredHeroList(enemyIds[i]);
                    var currentWeightedList = helper.GetWeightedList(enemyCounteredHeroList, enemyIds[i]).ToList();
                    //挨个合并列表
                    if (i == 0)
                    {
                        weightedList = currentWeightedList;
                    }
                    else
                    {
                        weightedList = helper.CombineList(currentWeightedList, weightedList).ToList();
                    }

                }

                //输出结果
                var resultList = helper.GetCalculateResult(weightedList);

                return Created(Request.RequestUri + "/" + enemyIds[0] + ":" + enemyIds.Last(), resultList);
            }
        }
    }
}
