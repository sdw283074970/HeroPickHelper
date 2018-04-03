using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Models
{
    public class ResultList
    {
        public IList<HeroToClient> Carries { get; set; }

        public IList<HeroToClient> Mids { get; set; }

        public IList<HeroToClient> Offlanes { get; set; }

        public IList<HeroToClient> RoamOrJuggles { get; set; }

        public IList<HeroToClient> Supports { get; set; }
    }
}