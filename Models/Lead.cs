namespace Models {
    public class Lead : Base {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganizationName { get; set; }
        public string Status { get; set; }
        public int? SourceID { get; set; }
        public int? UnqualifiedReasonID { get; set; }
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
    }
}
