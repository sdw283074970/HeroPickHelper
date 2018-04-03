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

        //1. 获取某个enemyId的Counter列表
            //根据前端传回的Id数组中的敌方英雄id，获取当前敌方英雄的counteredHeroList
        public IList<HeroCounter> GetEnemyCounteredHeroList(int enemyId)
        {
            return _context.HeroCounters.Where(c => c.Ida == enemyId).ToList();
        }


        //2. 将当前的敌方英雄Counter列表的克制指数权重化
            //根据当前敌方英雄和表中英雄的position，决定克制指数乘以的系数
        public int GetWeight(HeroCounter counteredHero)
        {
            if (counteredHero.Ida != counteredHero.Idb)
            {
                var enemy = _context.Heroes.Single(c => c.Id == counteredHero.Ida);
                var hero = _context.Heroes.Single(c => c.Id == counteredHero.Idb);
                var weight = _context.Weights.Single(c => c.EnemyHeroPosition == enemy.Position && c.CounteredHeroPosition == hero.Position);
                return weight.WeightIndex;
            }
            else
                return 1;
        }

            //将单独的英雄List<HeroCounter>按照当前情况(敌方英雄)乘以权重
        public IList<HeroCounter> GetWeightedList(IList<HeroCounter> enemyCounteredHeroList, int enemyId)
        {
            foreach(var counteredHero in enemyCounteredHeroList)
            {
                counteredHero.Value = counteredHero.Value * GetWeight(counteredHero);
            }

            return enemyCounteredHeroList;
        }

        //3. 如果前端传回的敌方英雄大于一，则执行此步骤，否则跳过。将所有英雄的克制结果表合并
            //将两个List<HeroCounter>列表按照索引位置将Value值加起来，返回结果List<HeroCounter>
        public IList<HeroCounter> CombineList(IList<HeroCounter> weightedLista, IList<HeroCounter> weightedListb)
        {
            for(int i = 0; i < 115; i++)
            {
                weightedLista[i].Value += weightedListb[i].Value;
            }

            return weightedLista;
        }

        //4. 将返回得到的合并后的列表按照value排序(此时的敌方英雄Ida已经不重要了，重要的是Idb)
            //并且按照value降序顺序输出候选英雄的Idb
        public IList<HeroCounter> OrderList(IList<HeroCounter> combindList)
        {
            return combindList.OrderByDescending(c => c.Value).ToList();
        }

        ////5. 将以上方法封装成一个方法，方便调用
        //public IList<HeroCounter> GetOrderedList(int[] enemyIds)
        //{
        //    foreach (var enemyId in enemyIds)
        //    {
        //        var enemyCounteredHeroList = GetEnemyCounteredHeroList(enemyId);
        //        var weightedList = GetWeightedList(enemyCounteredHeroList, enemyId);
        //    }


        //}


        //6. 将结果按照职责分割成五个部分，传回给客户端
        //将"查找HeroDuty列表中含有DutyId为1的对象(这个对象包含了英雄Id的信息)"这个过程封装成方法
        //有了英雄克制数据库后，在这个方法里面写算法
        //目前按照英雄Id顺序返回所有12345号位，有了克制数据库和算法后，将按照克制指数排序后再返回
        //目前返回前五位英雄
        public IList<HeroToClient> GetDutyInfo(int dutyId, IList<HeroCounter> orderedList)
        {
            var result = new List<HeroToClient>();
            //找出哪些orderedList的英雄是拥有当前dutyId的，将所有目标职责的英雄id返回
            var q = _context.DutyHeroes
                .Where(c => c.DutyId == dutyId)
                .Select(c => c.HeroId)
                .ToList();

            //查找当前列表中是否含有目标职责的英雄id，将所有符合条件的英雄封装进HeroToClient列表
            foreach (var validRecord in orderedList)
            {
                if (q.Contains(validRecord.Idb))
                {
                    var newResult = new HeroToClient()
                    {
                        Id = validRecord.Idb,
                        Index = validRecord.Value,
                        localized_name = _context.Heroes.Single(c => c.Id == validRecord.Idb).Localized_name,
                        url_small_portrait = _context.Heroes.Single(c => c.Id == validRecord.Idb).Url_small_portrait,
                        url_vertical_portrait = _context.Heroes.Single(c => c.Id == validRecord.Idb).Url_vertical_portrait
                    };
                    result.Add(newResult);
                }
            }

            return result;
        }
    }
}