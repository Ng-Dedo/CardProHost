using ServiceStack;

namespace CardProHost.DTOs {
    [Route("/card/authenticate")]
    public class CardAuthentication : Authenticate {
        public string CardHolderName { get; set; }
        public string PIN { get; set; }
        public string CVV { get; set; }
    }
}