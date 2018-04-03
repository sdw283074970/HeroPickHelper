using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Models
{
    public class Weight
    {
        public int Id { get; set; }
        public string EnemyHeroPosition { get; set; }
        public string CounteredHeroPosition { get; set; }
        public int WeightIndex { get; set; }
    }
}