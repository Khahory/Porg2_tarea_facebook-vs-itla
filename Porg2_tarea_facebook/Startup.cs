using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Porg2_tarea_facebook.Startup))]
namespace Porg2_tarea_facebook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
