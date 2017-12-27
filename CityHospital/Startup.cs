using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CityHospital.Startup))]
namespace CityHospital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
