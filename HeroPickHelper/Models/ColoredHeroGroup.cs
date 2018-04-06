using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Models
{
    public class ColoredHeroGroup
    {
        public IList<Hero> Purple { get; set; }
        public IList<Hero> Red { get; set; }
        public IList<Hero> Blue { get; set; }
        public IList<Hero> Yellow { get; set; }
        public IList<Hero> Green { get; set; }
        public IList<Hero> White { get; set; }

    }
}