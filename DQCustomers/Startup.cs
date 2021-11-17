using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DQCustomers.Startup))]
namespace DQCustomers
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
