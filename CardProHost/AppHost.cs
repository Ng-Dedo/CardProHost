using ServiceStack;
using Funq;
using CardProHost.Services;
using log4net;
using ServiceStack.Auth;
using CardProHost.Utils;
using System;

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

            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[] {
                    new JwtAuthProvider(AppSettings) {
                        PrivateKey = RsaUtils.CreatePrivateKeyParams(RsaKeyLengths.Bit2048),
                        RequireSecureConnection = false, //TODO: remove in production
                        CreatePayloadFilter = FilterUtils.JWTPayloadFilter,
                        EncryptPayload = true,
                        ExpireTokensIn = TimeSpan.FromDays(1)
                    },
                    new CardProAuthentication()
                }
            ));
        }
    }
}