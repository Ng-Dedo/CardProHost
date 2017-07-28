using ServiceStack;

namespace CardProHost.DTOs {
    [Route("/card/register")]
    public class CardRegister {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Card Card { get; set; }

        public Province Province { get; set; }
    }
}