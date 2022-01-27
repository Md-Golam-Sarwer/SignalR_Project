using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatHubWebApplication.Startup))]
namespace ChatHubWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.MapSignalR();
            app.MapConnection<EmpChatPer>("/echo");
        }
    }
}
