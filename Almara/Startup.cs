using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Almara.Startup))]
namespace Almara
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
