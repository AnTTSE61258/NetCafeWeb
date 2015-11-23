using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetCafeWeb.Startup))]
namespace NetCafeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
