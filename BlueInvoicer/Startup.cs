using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueInvoicer.Startup))]
namespace BlueInvoicer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
