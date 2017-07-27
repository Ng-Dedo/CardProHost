using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;
using System;
using System.Collections.Generic;

namespace CardProHost {
    public class CardProAuthentication: CredentialsAuthProvider {
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password) {
           return userName.Contains("Dedo") && password.Contains("Dedo");
        }

        public override IHttpResult OnAuthenticated(IServiceBase authService,
            IAuthSession session, IAuthTokens tokens,
            Dictionary<string, string> authInfo) {
            session.FirstName = $"Dedo {DateTime.Now}";
            return base.OnAuthenticated(authService, session, tokens, authInfo);
        }
    }
}