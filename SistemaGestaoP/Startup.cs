using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaGestaoP.Startup))]
namespace SistemaGestaoP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
