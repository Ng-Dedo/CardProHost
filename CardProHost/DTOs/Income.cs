using ServiceStack;

namespace CardProHost.DTOs {
    public class Income {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Route("/incomes")]
    public class IncomeWrapper : DTOWrapper<Income>
    {

    }
}