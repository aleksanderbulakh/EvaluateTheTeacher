using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AvaluateTheTeacher1.Startup))]
namespace AvaluateTheTeacher1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
