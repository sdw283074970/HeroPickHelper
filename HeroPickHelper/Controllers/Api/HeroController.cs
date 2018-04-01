using AutoMapper;
using HeroPickHelper.Dtos;
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
    public class HeroController : ApiController
    {
        private ApplicationDbContext _context;

        public HeroController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/hero
        public IHttpActionResult GetHeroList()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var heroesDto= _context.Heroes.Select(Mapper.Map<Hero, HeroDto>);

            return Ok(heroesDto);
        }

        // GET /api/hero
        public IHttpActionResult GetHero(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var hero = _context.Heroes.SingleOrDefault(c => c.Id == id);
            if (hero == null)
                return NotFound();

            return Ok(Mapper.Map<Hero, HeroDto>(hero));
        }

        // POST /api/hero
        [HttpPost]
        public IHttpActionResult CreatedHeroes(IEnumerable<HeroDto> heroesDto)
        {
            var heroes = new List<Hero>();
            int i = 0;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //在忽略DutyHeroes列表对象的情况下将hero添加进数据库
            foreach (var heroDto in heroesDto)
            {
                var hero = Mapper.Map<HeroDto, Hero>(heroDto);
                heroes.Add(hero);
            }

            _context.Heroes.AddRange(heroes);
            _context.SaveChanges();

            //将数据库分配的heroId传递给Dto
            foreach (var heroDto in heroesDto)
            {
                heroDto.Id = heroes[i].Id;
                i = i + 1;
            }

            i = 0;

            //根据heroDto自带的职责列表，建立英雄职责列表对象，添加进DutyHeroes列表中，并关联hero和duty
            foreach (var heroDto in heroesDto)
            {
                var heroInDb = _context.Heroes.SingleOrDefault(c => c.Nick_name == heroDto.Nick_name);

                foreach (var heroDutyDto in heroDto.DutyHeroes)
                {
                    heroDutyDto.HeroId = heroes[i].Id;     //重新附上数据库分配的Id给对象

                    var heroDuty = new DutyHero()
                    {
                        //导航属性必须是从数据库中查询获得的对象
                        Hero = _context.Heroes.Single(c => c.Id == heroDutyDto.HeroId),
                        Duty = _context.Duties.Single(c => c.Id == heroDutyDto.DutyId)
                    };

                    //添加中间表数据
                    _context.DutyHeroes.Add(heroDuty);
                }
            }

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + heroes[0].Id + ":" + heroes[heroes.Count - 1].Id), heroesDto);
        }

        //PUT /api/hero/{id} 这个批量更改的方法依赖Name字段，Dto中请不要更改这个字段
        [HttpPut]
        public void EditedHeroes(IEnumerable<HeroDto> heroesDto)
        {
            foreach (var heroDto in heroesDto)
            {
                var heroInDb = _context.Heroes.Include(c => c.DutyHeroes).Single(c => c.Name == heroDto.Name);

                //将Dto的值赋予heroInDb(Id和中间表列表已忽略)
                Mapper.Map(heroDto, heroInDb);

                _context.SaveChanges();

                //获得数据库中当前英雄的职责列表(中间表)
                var dutiesInDb = _context.DutyHeroes.Where(c => c.HeroId == heroInDb.Id);

                //如果数据库中这个英雄职责不为空
                if (dutiesInDb != null)
                {
                    //如果Dto中的英雄职责数据也不为空
                    if (heroDto.DutyHeroes != null)
                    {
                        //直接移除数据库中这个英雄职责(干脆推到重来，避免逻辑缠绕)
                        _context.DutyHeroes.RemoveRange(dutiesInDb);
                        _context.SaveChanges();

                        //重新建立中间表数据
                        foreach (var heroDutyDto in heroDto.DutyHeroes)
                        {
                            //新建中间表数据
                            var heroDuty = new DutyHero()
                            {
                                //导航属性必须是从数据库中查询获得的对象
                                Hero = _context.Heroes.Single(c => c.Name == heroDto.Name),        //这里用的导航实体
                                Duty = _context.Duties.Single(c => c.Id == heroDutyDto.DutyId)
                            };

                            //添加中间表数据
                            _context.DutyHeroes.Add(heroDuty);
                        }
                    }
                    //如果Dto中的英雄职责数据为空，则直接删除中间表数据，严格与Dto同步
                    else
                    {
                        //删除中间表数据
                        _context.DutyHeroes.RemoveRange(dutiesInDb);
                        _context.SaveChanges();

                    }
                }

                //如果数据库中的英雄职责为空
                else
                {
                    //如果Dto中的职责数据不为空
                    if(heroDto.DutyHeroes != null)
                    {
                        //直接在中间表中添加新数据
                        foreach (var heroDutyDto in heroDto.DutyHeroes)
                        {
                            //新建中间表数据
                            var heroDuty = new DutyHero()
                            {
                                //导航属性必须是从数据库中查询获得的对象
                                //Hero的数据库实体查询用Name是因为heroDto中不一定提供HeroId
                                Hero = _context.Heroes.Single(c => c.Name == heroDto.Name),
                                Duty = _context.Duties.Single(c => c.Id == heroDutyDto.DutyId)      //heroDto直接提供DutyId
                            };

                            //添加中间表数据
                            _context.DutyHeroes.Add(heroDuty);
                        }
                    }
                    //隐藏逻辑：如果Dto中的职责数据也为空，则什么都不做
                }
                _context.SaveChanges();
            }
        }
    }
}
