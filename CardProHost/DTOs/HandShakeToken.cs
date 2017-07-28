using ServiceStack;

namespace CardProHost.DTOs {
    [Route("/handshake/")]
    public class HandShakeToken {
        public string Token { get; set; }
    }
}