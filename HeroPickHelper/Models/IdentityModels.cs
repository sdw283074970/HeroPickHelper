using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HeroPickHelper.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<DutyHero> DutyHeroes { get; set; }

        //// 1~10 heroes
        //public DbSet<HeroCounter> AntiMage { get; set; }
        //public DbSet<HeroCounter> Axe { get; set; }
        //public DbSet<HeroCounter> Bane { get; set; }
        //public DbSet<HeroCounter> Bloodseeker { get; set; }
        //public DbSet<HeroCounter> CrystalMaiden { get; set; }
        //public DbSet<HeroCounter> DrowRanger { get; set; }
        //public DbSet<HeroCounter> Earthshaker { get; set; }
        //public DbSet<HeroCounter> Juggernaut { get; set; }
        //public DbSet<HeroCounter> Mirana { get; set; }
        //public DbSet<HeroCounter> Morphling { get; set; }
        //public DbSet<HeroCounter> ShadowFiend { get; set; }

        ////11~20heroes
        //public DbSet<HeroCounter> PhantomLancer { get; set; }
        //public DbSet<HeroCounter> Puck { get; set; }
        //public DbSet<HeroCounter> Pudge { get; set; }
        //public DbSet<HeroCounter> Razor { get; set; }
        //public DbSet<HeroCounter> SandKing { get; set; }
        //public DbSet<HeroCounter> StormSpirit { get; set; }
        //public DbSet<HeroCounter> Sven { get; set; }
        //public DbSet<HeroCounter> Tiny { get; set; }
        //public DbSet<HeroCounter> VengefulSpirit { get; set; }
        //public DbSet<HeroCounter> Windranger { get; set; }
        //public DbSet<HeroCounter> Zeus { get; set; }

        ////21~30heroes
        //public DbSet<HeroCounter> Kunkka { get; set; }
        //public DbSet<HeroCounter> Lina { get; set; }
        //public DbSet<HeroCounter> Lion { get; set; }
        //public DbSet<HeroCounter> ShadowShaman { get; set; }
        //public DbSet<HeroCounter> Slardar { get; set; }
        //public DbSet<HeroCounter> Tidehunter { get; set; }
        //public DbSet<HeroCounter> WitchDoctor { get; set; }
        //public DbSet<HeroCounter> Lich { get; set; }
        //public DbSet<HeroCounter> Riki { get; set; }
        //public DbSet<HeroCounter> Enigma { get; set; }
        //public DbSet<HeroCounter> Tinker { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}