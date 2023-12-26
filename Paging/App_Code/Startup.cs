using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Paging.Startup))]
namespace Paging
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
