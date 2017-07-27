using CardProHost.DTOs;
using ServiceStack;

namespace CardProHost.Services {
    public class CardProService : Service {
        public object Any(HandShakeToken handshake) {
            return new { token = handshake?.Token  };
        }   

        [Authenticate]
        public object Post(CardRegister cardRegister) {
            return new { result = $"{cardRegister.Name} - {cardRegister.Type}" };
        }
    }
}