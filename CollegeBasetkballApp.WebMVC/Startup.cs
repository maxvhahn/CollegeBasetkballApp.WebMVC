using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollegeBasetkballApp.WebMVC.Startup))]
namespace CollegeBasetkballApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
