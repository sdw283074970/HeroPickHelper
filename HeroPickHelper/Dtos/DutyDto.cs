using HeroPickHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Dtos
{
    public class DutyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DutyHero> DutyHeroes { get; set; }
    }
}