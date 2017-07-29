using ServiceStack;

namespace CardProHost.DTOs {
    public class Gender {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Route("/genders")]
    public class GenderWrapper : DTOWrapper<Gender>
    {

    }
}