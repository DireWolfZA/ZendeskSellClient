using System.Collections.Generic;

namespace Models {
    public class Base {
        public int ID { get; set; }
        public string Link { get; set; }
        public int CreatorID { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public int? OwnerID { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public Dictionary<string, object> CustomFields { get; set; }
    }
}
