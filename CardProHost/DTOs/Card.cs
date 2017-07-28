using static CardProHost.Constants.Constants;

namespace CardProHost.DTOs {
    public class Card {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardType Type { get; set; }
    }
}