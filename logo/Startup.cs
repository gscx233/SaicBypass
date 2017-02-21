using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(logo.Startup))]
namespace logo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
