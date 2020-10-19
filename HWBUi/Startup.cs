using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWBUi.Startup))]
namespace HWBUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
