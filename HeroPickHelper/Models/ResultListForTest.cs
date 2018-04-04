using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Models
{
    //这个类是为了测试api所建立，今后会删掉
    public class ResultListForTest
    {
        public IList<Hero> Carries { get; set; }

        public IList<Hero> Mids { get; set; }

        public IList<Hero> Offlanes { get; set; }

        public IList<Hero> RoamOrJuggles { get; set; }

        public IList<Hero> Supports { get; set; }
    }
}