using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;
using System.Collections.Generic;

namespace CardProHost {
    public class CardProAuthentication : CredentialsAuthProvider {
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password) {
            return userName.Contains("Dedo") && password.Contains("Dedo");
        }

        public override object Authenticate(IServiceBase authService, IAuthSession session, Authenticate request) {
            return base.Authenticate(authService, session, request);
        }

        public override IHttpResult OnAuthenticated(IServiceBase authService,
            IAuthSession session, IAuthTokens tokens,
            Dictionary<string, string> authInfo) {

            session.Id = null;
            if (session.UserAuthName.Contains("VIP")) {
                session.Permissions = new List<string> { "canGetCards" };
            }

            return base.OnAuthenticated(authService, session, tokens, authInfo);
        }
    }
}