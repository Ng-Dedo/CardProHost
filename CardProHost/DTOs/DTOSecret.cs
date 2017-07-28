using CardProHost.RequestFilters;

namespace CardProHost.DTOs {
    [DecryptFilter]
    public class DTOSecret {

        public string Data { get; set; }

    }
}