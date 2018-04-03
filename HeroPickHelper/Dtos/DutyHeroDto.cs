using HeroPickHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Dtos
{
    public class DutyHeroDto
    {
        public int Id { get; set; }
        
        public HeroToclient Hero { get; set; }

        public int HeroId { get; set; }
        
        public Duty Duty { get; set; }

        public int DutyId { get; set; }
    }
}