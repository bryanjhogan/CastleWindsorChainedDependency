using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CastleWindsorChainedDependency.Startup))]
namespace CastleWindsorChainedDependency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
