using CardProHost.DTOs;
using ServiceStack;

namespace CardProHost.Services {
    public class CardProService : Service {

        public object Post(CardRegister cardRegister) {
            var decryptedCardRegister = cardRegister.Data.FromJson<CardRegister>();
            return new HttpResult(decryptedCardRegister);
        }
    }
}