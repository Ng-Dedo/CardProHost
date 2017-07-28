using ServiceStack;

namespace CardProHost.DTOs {
    [Route("/handshake/")]
    public class HandShake {
        public string Key { get; set; }
        public string Challenge { get; set; }
    }
}