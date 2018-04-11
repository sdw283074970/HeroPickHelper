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

        // Get hero's duties 以string格式返回某一具体英雄Id拥有的职责名称(测试用)
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
            var test = _context.HeroCounters.Where(c => c.Ida == 9).ToList();
            var enemiesOfEnemy = _context.HeroCounters.Where(c => c.Ida == enemyId).ToList();
            return enemiesOfEnemy;
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
        
        //5. 按照职责列表分别算出每个职责对应的结果列表，如计算Carry结果列表
            //返回的结果列表不应该包含已选择的敌方英雄

        //GET方法的重载（测试用）
        public IList<Hero> GetDutyInfo(int dutyId)
        {
            return _context.DutyHeroes.Where(c => c.DutyId == dutyId).Select(c => c.Hero).ToList();
        }

        //POST方法的重载
        public IList<HeroToClient> GetDutyInfo(int dutyId, IList<HeroCounter> orderedList, int[] enemyIds)
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
                //遍历已排序的列表，如果得出的职责英雄id列表中有结果列表中的英雄id，且这个id不是敌方英雄，则输入进结果列表中
                if (q.Contains(validRecord.Idb) && !enemyIds.Contains(validRecord.Idb))
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

        //将第4~5步骤封装
        public ResultList GetCalculateResult(IList<HeroCounter> weightedList, int[] enemyIds)
        {
            var orderedList = OrderList(weightedList);

            //从orderedList中分别获取12345号位的表，分成五部分封装在json数组(ResultList类型)中返回
            var carriesInfo = GetDutyInfo(1, orderedList, enemyIds);
            var midsInfo = GetDutyInfo(2, orderedList, enemyIds);
            var offlanesInfo = GetDutyInfo(3, orderedList, enemyIds);
            var roamAndJunglesInfo = GetDutyInfo(4, orderedList, enemyIds);
            var supportsInfo = GetDutyInfo(5, orderedList, enemyIds);

            //返回这个计算结果列表给前端
            var resultList = new ResultList()
            {
                Carries = carriesInfo,
                Mids = midsInfo,
                RoamOrJuggles = roamAndJunglesInfo,
                Offlanes = offlanesInfo,
                Supports = supportsInfo
            };

            return resultList;
        }
    }
}