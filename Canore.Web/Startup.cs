using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Canore.Web.Startup))]
namespace Canore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
