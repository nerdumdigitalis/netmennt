using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Netmennt.Startup))]
namespace Netmennt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
