using System.Collections.Generic;
using System.Linq;

namespace Models {
    public class Base {
        public long ID { get; set; }
        public string Link { get; set; }
        public int CreatorID { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public int? OwnerID { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();
        public Dictionary<string, object> CustomFields { get; set; } = new Dictionary<string, object>();
    }
}
