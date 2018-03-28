using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeroPickHelper.Startup))]
namespace HeroPickHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
