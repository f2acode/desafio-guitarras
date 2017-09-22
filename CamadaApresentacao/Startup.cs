using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CamadaApresentacao.Startup))]
namespace CamadaApresentacao
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
