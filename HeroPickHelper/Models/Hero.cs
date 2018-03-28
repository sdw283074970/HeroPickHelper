using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nick_name { get; set; }

        public string Localized_name { get; set; }

        public string Url_full_portrait { get; set; }

        public string Url_small_portrait { get; set; }

        public string Url_large_portrait { get; set; }

        public string Url_vertical_portrait { get; set; }

        public string Position { get; set; }

        public ICollection<DutyHero> DutyHeroes { get; set; }
    }
}