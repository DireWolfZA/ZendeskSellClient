using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helpers;

namespace Controls {
    public partial class ContactPropertyGrid : IZendeskPropertyGrid<Models.Contact> {
        private readonly IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields;
        private readonly Dictionary<int, string> users;

        private readonly Dictionary<string, Control> customFieldControls = new Dictionary<string, Control>();

        public ContactPropertyGrid(Forms.Settings settings, IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields, Dictionary<int, string> users) {
            this.customFields = customFields;
            this.users = users;

            InitializeComponent();
            txtLink.LinkClicked += ZendeskPropertyGridMethods.LinkLabel_LinkClicked;
            btnAddressEdit.Click += (s, e) => ZendeskPropertyGridMethods.AddressEditButton_Click(settings, txtAddress);
            btnBillingAddressEdit.Click += (s, e) => ZendeskPropertyGridMethods.AddressEditButton_Click(settings, txtBillingAddress);
            btnShippingAddressEdit.Click += (s, e) => ZendeskPropertyGridMethods.AddressEditButton_Click(settings, txtShippingAddress);
            btnTagsEdit.Click += (s, e) => ZendeskPropertyGridMethods.TagEditButton_Click(settings, txtTags);

            scMain.Tag = false;
            scMain.Panel1.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel1_Scroll(scMain);
            scMain.Panel2.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel2_Scroll(scMain);

            cbxOwner.Items.Clear();
            cbxOwner.Items.AddRange(users.Values.ToArray());

            ZendeskPropertyGridMethods.CreateCustomFields(customFields, customFieldControls, pnlCustomFieldLabels, pnlCustomFieldValues);

            ApplyTheme(settings.GetTheme());
            settings.ThemeChanged += ApplyTheme;
        }

        public override void ApplyTheme(WalkmanLib.Theme theme) {
            Theming.ApplyTheme(theme, Controls);
            Theming.ApplyTheme(theme, components?.Components);
        }

        public override void SetData(Models.Contact data) {
            this.Tag = data;

            txtID.Text = data.ID.ToString();
            txtLink.Text = data.Link;
            txtCreator.Text = users.ContainsKey(data.CreatorID) ? users[data.CreatorID] : null;
            txtCreatedAt.Text = data.CreatedAt;
            txtUpdatedAt.Text = data.UpdatedAt;
            txtIsOrganization.Text = data.IsOrganization.ToString();

            cbxOwner.Text = data.OwnerID.HasValue ? users[data.OwnerID.Value] : null;
            txtName.Text = data.Name;
            txtFirstName.Text = data.FirstName;
            txtLastName.Text = data.LastName;
            txtContactID.Text = data.ContactID.ToString();
            txtParentOrganizationID.Text = data.ParentOrganizationID.ToString();
            cbxCustomerStatus.Text = data.CustomerStatus;
            cbxProspectStatus.Text = data.ProspectStatus;
            txtTitle.Text = data.Title;
            txtDescription.Text = data.Description;
            txtIndustry.Text = data.Industry;
            txtWebsite.Text = data.Website;
            txtEmail.Text = data.Email;
            txtPhone.Text = data.Phone;
            txtMobile.Text = data.Mobile;
            txtFax.Text = data.Fax;
            txtTwitter.Text = data.Twitter;
            txtFacebook.Text = data.Facebook;
            txtLinkedin.Text = data.LinkedIn;
            txtSkype.Text = data.Skype;
            txtAddress.Text = data.Address?.ToTextOneLine();
            txtAddress.Tag = data.Address;
            txtBillingAddress.Text = data.BillingAddress?.ToTextOneLine();
            txtBillingAddress.Tag = data.BillingAddress;
            txtShippingAddress.Text = data.ShippingAddress?.ToTextOneLine();
            txtShippingAddress.Tag = data.ShippingAddress;
            txtTags.Text = string.Join(',', data.Tags);
            txtTags.Tag = data.Tags;

            ZendeskPropertyGridMethods.SetCustomFieldValues(customFields, customFieldControls, data.CustomFields);
        }

        public override Models.Contact GetData() {
            var rtn = new Models.Contact() {
                ID = (this.Tag as Models.Contact ?? new Models.Contact()).ID,
                IsOrganization = bool.TryParse(txtIsOrganization.Text, out var result) ? result : false,

                OwnerID = users.ContainsValue(cbxOwner.Text) ? users.First(kv => kv.Value == cbxOwner.Text).Key : (int?)null,
                Name = txtName.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                ContactID = string.IsNullOrWhiteSpace(txtContactID.Text) ? (int?)null : int.Parse(txtContactID.Text),
                ParentOrganizationID = string.IsNullOrWhiteSpace(txtParentOrganizationID.Text) ? (int?)null : int.Parse(txtParentOrganizationID.Text),
                CustomerStatus = cbxCustomerStatus.Text,
                ProspectStatus = cbxProspectStatus.Text,
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Industry = txtIndustry.Text,
                Website = txtWebsite.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Mobile = txtMobile.Text,
                Fax = txtFax.Text,
                Twitter = txtTwitter.Text,
                Facebook = txtFacebook.Text,
                LinkedIn = txtLinkedin.Text,
                Skype = txtSkype.Text,
                Address = txtAddress.Tag as Models.Address ?? new Models.Address(),
                BillingAddress = txtBillingAddress.Tag as Models.Address ?? new Models.Address(),
                ShippingAddress = txtShippingAddress.Tag as Models.Address ?? new Models.Address(),
                Tags = txtTags.Tag as IEnumerable<string> ?? new string[0]
            };

            rtn.CustomFields = ZendeskPropertyGridMethods.GetCustomFieldValues(customFields, customFieldControls);

            return rtn;
        }

        public override void SetMultiState() {
            ZendeskPropertyGridMethods.SetCustomFieldsMultiState(customFields, customFieldControls);
        }

        public override Models.Contact ApplyUpdate(Models.Contact data) {
            if (users.ContainsValue(cbxOwner.Text))
                data.OwnerID = users.First(kv => kv.Value == cbxOwner.Text).Key;
            if (!string.IsNullOrWhiteSpace(txtName.Text))
                data.Name = txtName.Text;
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                data.FirstName = txtFirstName.Text;
            if (!string.IsNullOrWhiteSpace(txtLastName.Text))
                data.LastName = txtLastName.Text;
            if (!string.IsNullOrWhiteSpace(txtContactID.Text))
                data.ContactID = int.Parse(txtContactID.Text);
            if (!string.IsNullOrWhiteSpace(txtParentOrganizationID.Text))
                data.ParentOrganizationID = int.Parse(txtParentOrganizationID.Text);
            if (!string.IsNullOrWhiteSpace(cbxCustomerStatus.Text))
                data.CustomerStatus = cbxCustomerStatus.Text;
            if (!string.IsNullOrWhiteSpace(cbxProspectStatus.Text))
                data.ProspectStatus = cbxProspectStatus.Text;
            if (!string.IsNullOrWhiteSpace(txtTitle.Text))
                data.Title = txtTitle.Text;
            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
                data.Description = txtDescription.Text;
            if (!string.IsNullOrWhiteSpace(txtIndustry.Text))
                data.Industry = txtIndustry.Text;
            if (!string.IsNullOrWhiteSpace(txtWebsite.Text))
                data.Website = txtWebsite.Text;
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                data.Email = txtEmail.Text;
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
                data.Phone = txtPhone.Text;
            if (!string.IsNullOrWhiteSpace(txtMobile.Text))
                data.Mobile = txtMobile.Text;
            if (!string.IsNullOrWhiteSpace(txtFax.Text))
                data.Fax = txtFax.Text;
            if (!string.IsNullOrWhiteSpace(txtTwitter.Text))
                data.Twitter = txtTwitter.Text;
            if (!string.IsNullOrWhiteSpace(txtFacebook.Text))
                data.Facebook = txtFacebook.Text;
            if (!string.IsNullOrWhiteSpace(txtLinkedin.Text))
                data.LinkedIn = txtLinkedin.Text;
            if (!string.IsNullOrWhiteSpace(txtSkype.Text))
                data.Skype = txtSkype.Text;
            if (!string.IsNullOrWhiteSpace((txtAddress.Tag as Models.Address)?.ToTextMultiLine()?.Trim()))
                data.Address = txtAddress.Tag as Models.Address;
            if (!string.IsNullOrWhiteSpace((txtBillingAddress.Tag as Models.Address)?.ToTextMultiLine()?.Trim()))
                data.BillingAddress = txtBillingAddress.Tag as Models.Address;
            if (!string.IsNullOrWhiteSpace((txtShippingAddress.Tag as Models.Address)?.ToTextMultiLine()?.Trim()))
                data.ShippingAddress = txtShippingAddress.Tag as Models.Address;
            if (!string.IsNullOrWhiteSpace(string.Concat(txtTags.Tag as IEnumerable<string> ?? Enumerable.Empty<string>())?.Trim()))
                data.Tags = txtTags.Tag as IEnumerable<string>;

            data.CustomFields = ZendeskPropertyGridMethods.ApplyCustomFieldValues(customFields, customFieldControls, data.CustomFields);

            return data;
        }
    }
}
