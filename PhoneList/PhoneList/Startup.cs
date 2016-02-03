using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhoneList.Startup))]
namespace PhoneList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
