using CardProHost.DTOs;
using System.Collections.Generic;
using System.Linq;
using static CardProHost.Constants.Constants;

namespace CardProHost.Services {

    public static class MockService {
        private static List<Card> cards;
        private static IEnumerable<Province> provinces;
        private static IEnumerable<Income> incomes;
        private static IEnumerable<Gender> genders;

        static MockService (){
            cards = new List<Card>();
            for (var i = 0; i < 50; i++) {
                cards.Add(new Card {
                    Id = i,
                    Name = "Sacombank " + (i % 2 == 0 ? "Platinum" : "Gold"),
                    Type = i % 2 == 0 ? CardType.Credit : CardType.Debit
                });
            }

            provinces = new List<Province> {
                new Province {
                    Id = 1,
                    Name = "Ho Chi Minh"
                },
                new Province {
                    Id = 2,
                    Name = "Ha Noi"
                }
            };
            incomes = new List<Income> {
                new Income {
                    Id = 1,
                    Name = "7-12 trieu"
                },
                new Income {
                    Id = 2,
                    Name = "12-18 trieu"
                }
            };
            genders = new List<Gender> {
                new Gender {
                    Id = 1,
                    Name = "Nam"
                },
                new Gender {
                    Id = 2,
                    Name = "Nu"
                }
            };
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

        public static IEnumerable<Province> GetProvinces(){
            return provinces;
        }

        public static IEnumerable<Province> GetIncomes() {
            return provinces;
        }

        public static IEnumerable<Gender> GetGenders() {
            return genders;
        }

    }
}