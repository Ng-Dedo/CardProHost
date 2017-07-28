using CardProHost.DTOs;
using ServiceStack;
using System.Net;

namespace CardProHost.Services {
    public class CardProService : Service {
        public object Post(HandShake handshake) {
            return new { token = handshake?.Key  };
        }   

        public object Post(CardRegister cardRegister) {
            return new HttpResult(HttpStatusCode.OK, "Successfully");
        }

        #region reference services

        [Route("/cards", "GET")]
        [Authenticate]
        [RequiredPermission("canGetCards")]
        public object Cards(DTOWrapper<Card> dto) {
            return MockService.GetCards(dto);
        }

        [Route("/provinces", "GET")]
        public object Provinces() {
            return MockService.GetProvinces();
        }

        [Route("/incomes", "GET")]
        public object Incomes() {
            return MockService.GetIncomes();
        }


        [Route("/genders", "GET")]
        public object Genders() {
            return MockService.GetGenders();
        }

        #endregion
    }
}