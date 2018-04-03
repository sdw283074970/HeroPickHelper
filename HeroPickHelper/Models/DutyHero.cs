using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeroPickHelper.Models
{
    public class DutyHero
    {
        public int Id { get; set; }

        [ForeignKey("HeroId")]
        public HeroToclient Hero { get; set; }

        public int HeroId { get; set; }

        [ForeignKey("DutyId")]
        public Duty Duty { get; set; }

        public int DutyId { get; set; }
    }
}