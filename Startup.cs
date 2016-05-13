using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zarzadzanie_Projektami.Startup))]
namespace Zarzadzanie_Projektami
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
