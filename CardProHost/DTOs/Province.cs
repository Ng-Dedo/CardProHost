using ServiceStack;

namespace CardProHost.DTOs {
    public class Province {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Route("/provinces")]
    public class ProvinceWrapper : DTOWrapper<Province>
    {
    }
}