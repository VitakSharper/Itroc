using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.ITroc.Startup))]
namespace Web.ITroc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
