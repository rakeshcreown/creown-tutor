using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CreownTutor.Startup))]
namespace CreownTutor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
