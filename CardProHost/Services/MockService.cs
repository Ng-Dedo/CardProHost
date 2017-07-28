using CardProHost.DTOs;
using System.Collections.Generic;
using System.Linq;
using static CardProHost.Constants.Constants;

namespace CardProHost.Services {

    public static class MockService {
        private static List<Card> cards;

        static MockService (){
            cards = new List<Card>();
            for (var i = 0; i < 50; i++) {
                cards.Add(new Card {
                    Id = i,
                    Name = "Sacombank " + (i % 2 == 0 ? "Platinum" : "Gold"),
                    Type = i % 2 == 0 ? CardType.Credit : CardType.Debit
                });
            }
        }

        public static DTOWrapper<Card> GetCards(DTOWrapper<Card> dto) {

            var cards = MockService.cards
                .Where((x, i) => i >= dto.Index && i < (dto.Index + dto.NumberOfResults));

            return new DTOWrapper<Card> {
                Total = MockService.cards.Count,
                Index = dto.Index,
                NumberOfResults = dto.NumberOfResults,
                Results = cards
            };
        }

    }
}