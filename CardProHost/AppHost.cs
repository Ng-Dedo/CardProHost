using ServiceStack;
using Funq;
using CardProHost.Services;
using log4net;

namespace CardProHost {
    public class AppHost : AppHostBase {
        private readonly ILog _log = LogManager.GetLogger(typeof(AppHost));

        public AppHost()
           : base("CardProHost", typeof(CardProService).Assembly) {

        }

        public override void Configure(Container container) {
            SetConfig(new HostConfig {
                DebugMode = true,
                HandlerFactoryPath = "api",
                WebHostUrl = AppSettings.GetString("HostAddress")
            });
        }
    }
}