using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcGuestBook.Startup))]
namespace MvcGuestBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
