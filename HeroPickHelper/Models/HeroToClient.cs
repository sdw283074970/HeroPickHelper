using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Models
{
    public class HeroToClient
    {
        public int Id { get; set; }

        public string localized_name { get; set; }

        public string url_vertical_portrait { get; set; }

        public string url_small_portrait { get; set; }

        public int Index { get; set; }
    }
}