using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyAppy.Startup))]
namespace VidlyAppy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
