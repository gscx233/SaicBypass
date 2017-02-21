using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaicBypass.Startup))]
namespace SaicBypass
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
