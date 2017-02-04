using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectEulerAnswers.Startup))]
namespace ProjectEulerAnswers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
