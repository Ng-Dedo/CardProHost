using ServiceStack;

namespace CardProHost.DTOs {
    [Route("/handshake/{Token}")]
    public class HandShakeToken {
        public string Token { get; set; }
    }
}