using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NSTP.Startup))]
namespace NSTP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
