namespace Models {
    public class Contact : Base {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // read-only for existing contacts, can be set when creating
        public bool IsOrganization { get; set; }
        public int? ContactID { get; set; }
        public int? ParentOrganizationID { get; set; }
        public string CustomerStatus { get; set; }
        public string ProspectStatus { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Skype { get; set; }
        public Address Address { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
