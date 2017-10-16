using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trabajo2Web.Startup))]
namespace trabajo2Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
