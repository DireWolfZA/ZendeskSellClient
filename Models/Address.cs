using System;

namespace Models {
    public class Address : ZendeskSell.Models.Address {
        public Address() { }
        public Address(ZendeskSell.Models.Address source) : base(source) { }

        private bool IsNull() {
            if (this == null)
                return true;
            if (this.Line1 == null && City == null && State == null && PostalCode == null && Country == null)
                return true;
            return false;
        }

        public string ToTextOneLine() =>
            IsNull() ? null : string.Join(", ", new string[] { Line1, City, State, PostalCode, Country });
        public string ToTextMultiLine() =>
            IsNull() ? null : string.Join(Environment.NewLine, new string[] { Line1, City, State, PostalCode, Country });
    }
}
