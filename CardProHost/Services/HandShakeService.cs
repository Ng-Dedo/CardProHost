using CardProHost.DTOs;
using CardProHost.Utils;
using ServiceStack;

namespace CardProHost.Services {
    public class HandShakeService : Service {

        public object Post(HandShake handshake) {
            var userSession = SessionAs<AuthUserSession>();
            userSession.ClientSessionKey = handshake?.Key.RSACardProDecrypt();
            Request.SaveSession(userSession);
            var challenge = userSession.ClientSessionKey.AESCardProEncrypt(userSession.ClientSessionKey);
            return new HandShake { Key = handshake?.Key, Challenge = challenge  };
        }   
    }
}