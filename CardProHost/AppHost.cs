using ServiceStack;
using Funq;
using CardProHost.Services;
using log4net;
using ServiceStack.Auth;
using CardProHost.Utils;
using System;
using CardProHost.DTOs;
using ServiceStack.Authentication.OAuth2;

namespace CardProHost
{
    public class AppHost : AppHostBase
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(AppHost));

        public AppHost()
           : base("CardProHost", typeof(CardProService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
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
                    new CardProAuthentication(),
                    new GoogleOAuth2Provider(AppSettings) {
                        ConsumerKey = "916226986619-3l67d53pvpu0rrk9c80ea5t8rspg0mfe.apps.googleusercontent.com",
                        ConsumerSecret = "RJUfHrABtTabUM9bZfpnVd6C",
                    },
                }
            ));

            // TODO: remove in production
            Plugins.Add(new CorsFeature(allowCredentials: true, allowedHeaders: "Content-Type, Authorization"));
        }
    }
}