using CardProHost.DTOs;
using ServiceStack;

namespace CardProHost.Services {
    public class ReferenceService : Service {

        [Authenticate]
        [RequiredPermission("canGetCards")]
        public object Post(CardWrapper dto) {
            return MockService.GetCards(dto);
        }

        public object Post(ProvinceWrapper dto) {
            return MockService.GetProvinces();
        }

        public object Post(IncomeWrapper dto) {
            return MockService.GetIncomes();
        }

        public object Post(GenderWrapper dto) {
            return MockService.GetGenders();
        }

    }
}