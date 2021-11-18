namespace Models {
    public class LineItem : Base {
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        // discount is on the Order, and applies to all LineItems on that order
        public int? Discount { get; set; }
        public int? ProductID { get; set; }
        public string Value { get; set; }
        public string Variation { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }
    }
}
