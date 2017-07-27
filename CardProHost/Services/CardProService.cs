using CardProHost.DTOs;
using ServiceStack;
using ServiceStack.Auth;

namespace CardProHost.Services {
    public class CardProService : Service {
        public object Any(HandShakeToken handshake) {
            return new { token = handshake?.Token  };
        }   

        [Authenticate]
        [RequiredPermission("CanRegister")]
        public object Post(CardRegister cardRegister) {
            IAuthSession session = GetSession();
            return new { result = $"{session?.FirstName} - {cardRegister.Type}" };
        }
    }
}