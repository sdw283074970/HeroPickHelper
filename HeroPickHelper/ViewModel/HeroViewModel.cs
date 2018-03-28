using HeroPickHelper.Helper;
using HeroPickHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.ViewModel
{
    public class HeroViewModel
    {
        public IEnumerable<Hero> heroList { get; set; }
        public HeroDutyHelper helper { get; set; }
    }
}