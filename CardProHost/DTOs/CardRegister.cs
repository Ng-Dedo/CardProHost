using ServiceStack;

namespace CardProHost.DTOs {
    [Route("/card/register")]
    public class CardRegister {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}