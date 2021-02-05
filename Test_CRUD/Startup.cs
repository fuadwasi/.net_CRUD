using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_CRUD.Startup))]
namespace Test_CRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
