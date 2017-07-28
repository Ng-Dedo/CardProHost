using CardProHost.DTOs;
using ServiceStack;
using System.Net;

namespace CardProHost.Services {
    public class CardProService : Service {
        public object Any(HandShakeToken handshake) {
            return new { token = handshake?.Token  };
        }   

        public object Post(CardRegister cardRegister) {
            return new HttpResult(HttpStatusCode.OK, "Successfully");
        }

        [Route("/cards", "GET")]
        [Authenticate]
        [RequiredPermission("canGetCards")]
        public object Cards(DTOWrapper<Card> dto) {
            return MockService.GetCards(dto);
        }

    }
}