using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Mag.Startup))]
namespace E_Mag
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
