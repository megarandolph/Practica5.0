using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(practicacinco.cero.Startup))]
namespace practicacinco.cero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
