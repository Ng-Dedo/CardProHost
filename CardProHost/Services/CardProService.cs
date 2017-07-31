using CardProHost.DTOs;
using ServiceStack;
using System.Net;

namespace CardProHost.Services {
    public class CardProService : Service {

        public object Post(CardRegister cardRegister) {
            //var userSession = SessionAs<UserAuthSession>();
            return new HttpResult(HttpStatusCode.OK, "Successfully");
        }
    }
}