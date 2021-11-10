using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helpers;

namespace Controls {
    public partial class ContactPropertyGrid : IZendeskPropertyGrid<Models.Contact> {
        private readonly IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields;
        private readonly Dictionary<int, string> users;

        private readonly Dictionary<string, Control> customFieldControls = new Dictionary<string, Control>();

        public ContactPropertyGrid(IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields, Dictionary<int, string> users) {
            this.customFields = customFields;
            this.users = users;

            InitializeComponent();
            txtLink.LinkClicked += ZendeskPropertyGridMethods.LinkLabel_LinkClicked;
            btnAddressEdit.Click += (s, e) => ZendeskPropertyGridMethods.AddressEditButton_Click(txtAddress);
            btnBillingAddressEdit.Click += (s, e) => ZendeskPropertyGridMethods.AddressEditButton_Click(txtBillingAddress);
            btnShippingAddressEdit.Click += (s, e) => ZendeskPropertyGridMethods.AddressEditButton_Click(txtShippingAddress);
            btnTagsEdit.Click += (s, e) => ZendeskPropertyGridMethods.TagEditButton_Click(txtTags);

            scMain.Tag = false;
            scMain.Panel1.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel1_Scroll(scMain);
            scMain.Panel2.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel2_Scroll(scMain);

            cbxOwner.Items.Clear();
            cbxOwner.Items.AddRange(users.Values.ToArray());

            ZendeskPropertyGridMethods.CreateCustomFields(customFields, customFieldControls, pnlCustomFieldLabels, pnlCustomFieldValues);

            Theming.ApplyTheme(Controls);
            if (components != null)
                Theming.ApplyTheme(components.Components);
        }

        public override void SetData(Models.Contact data) {
            this.Tag = data;

            txtID.Text = data.ID.ToString();
            txtLink.Text = data.Link;
            if (users.ContainsKey(data.CreatorID))
                txtCreator.Text = users[data.CreatorID];
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
            txtAddress.Text = data.Address.ToTextOneLine();
            txtAddress.Tag = data.Address;
            txtBillingAddress.Text = data.BillingAddress.ToTextOneLine();
            txtBillingAddress.Tag = data.BillingAddress;
            txtShippingAddress.Text = data.ShippingAddress.ToTextOneLine();
            txtShippingAddress.Tag = data.ShippingAddress;
            txtTags.Text = string.Join(',', data.Tags);
            txtTags.Tag = data.Tags;

            ZendeskPropertyGridMethods.SetCustomFieldValues(customFields, customFieldControls, data.CustomFields);
        }

        public override Models.Contact GetData() {
            var rtn = new Models.Contact() {
                ID = ((Models.Contact)this.Tag).ID,
                IsOrganization = bool.Parse(txtIsOrganization.Text),

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
                Address = (Models.Address)txtAddress.Tag,
                BillingAddress = (Models.Address)txtBillingAddress.Tag,
                ShippingAddress = (Models.Address)txtShippingAddress.Tag,
                Tags = (IEnumerable<string>)txtTags.Tag
            };

            rtn.CustomFields = ZendeskPropertyGridMethods.GetCustomFieldValues(customFields, customFieldControls);

            return rtn;
        }
    }
}
