using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AviaServer.Startup))]
namespace AviaServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
