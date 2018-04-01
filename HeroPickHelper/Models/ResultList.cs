using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Models
{
    public class ResultList
    {
        public IList<Hero> Carries { get; set; }

        public IList<Hero> Mids { get; set; }

        public IList<Hero> Offlanes { get; set; }

        public IList<Hero> RoamOrJuggles { get; set; }

        public IList<Hero> Supports { get; set; }
    }
}