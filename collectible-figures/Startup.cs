using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(collectible_figures.Startup))]
namespace collectible_figures
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
