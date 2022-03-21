using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Car_Rent_All.Startup))]
namespace Car_Rent_All
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
