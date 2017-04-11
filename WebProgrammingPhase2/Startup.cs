using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebProgrammingPhase2.Startup))]
namespace WebProgrammingPhase2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
