using CardProHost.DTOs;
using CardProHost.Utils;
using ServiceStack;
using ServiceStack.Auth;

namespace CardProHost.Services {
    public class CardProService : Service {

        public object Post(CardRegister cardRegister) {
            var ssId = Request.Headers["X-ss-id"];
            var sessionKey = IdUtils.CreateUrn<IAuthSession>(ssId); //= urn:iauthsession:
            var userSession = Cache.Get<AuthUserSession>(sessionKey);
            cardRegister.Data = cardRegister.Data.AESCardProDecrypt(userSession?.ClientSessionKey);
            var decryptedCardRegister = cardRegister.Data.FromJson<CardRegister>();
            return new HttpResult(decryptedCardRegister);
        }
    }
}