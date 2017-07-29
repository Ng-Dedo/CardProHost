using CardProHost.DTOs;
using ServiceStack;
using System.Net;

namespace CardProHost.Services {
    public class CardProService : Service {

        public object Post(CardRegister cardRegister) {
            return new HttpResult(HttpStatusCode.OK, "Successfully");
        }
    }
}