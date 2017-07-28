
using System.Collections.Generic;

namespace CardProHost.DTOs {

    public class DTOWrapper<T> {

        public int Total { get; set; }

        public int Index { get; set; } 

        public int NumberOfResults { get; set; }

        public IEnumerable<T> Results { get; set; } = new List<T>();

    }
}