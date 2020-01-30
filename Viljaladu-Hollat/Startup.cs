using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Viljaladu_Hollat.Startup))]
namespace Viljaladu_Hollat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
