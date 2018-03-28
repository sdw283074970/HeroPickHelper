using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Models
{
    public class Duty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DutyHero> DutyHeroes { get; set; }
    }
}