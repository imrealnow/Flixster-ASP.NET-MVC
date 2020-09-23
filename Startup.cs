using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Flixster.Startup))]
namespace Flixster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
