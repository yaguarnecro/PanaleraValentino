using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoyectoFinalPañaleraValentino.Startup))]
namespace PoyectoFinalPañaleraValentino
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
