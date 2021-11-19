using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helpers;

namespace Controls {
    public partial class LeadPropertyGrid : IZendeskPropertyGrid<Models.Lead> {
        private readonly IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields;
        private readonly Dictionary<int, string> users;
        private readonly Dictionary<int, string> sources;

        private readonly Dictionary<string, Control> customFieldControls = new Dictionary<string, Control>();

        public LeadPropertyGrid(IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields, Dictionary<int, string> users, Dictionary<int, string> sources) {
            this.customFields = customFields;
            this.users = users;
            this.sources = sources;

            InitializeComponent();
            txtLink.LinkClicked += ZendeskPropertyGridMethods.LinkLabel_LinkClicked;
            btnAddressEdit.Click += (s, e) => ZendeskPropertyGridMethods.AddressEditButton_Click(txtAddress);
            btnTagsEdit.Click += (s, e) => ZendeskPropertyGridMethods.TagEditButton_Click(txtTags);

            scMain.Tag = false;
            scMain.Panel1.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel1_Scroll(scMain);
            scMain.Panel2.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel2_Scroll(scMain);

            cbxOwner.Items.Clear();
            cbxOwner.Items.AddRange(users.Values.ToArray());
            cbxSource.Items.Clear();
            cbxSource.Items.Add("");
            cbxSource.Items.AddRange(sources.Values.ToArray());
            ZendeskPropertyGridMethods.CreateCustomFields(customFields, customFieldControls, pnlCustomFieldLabels, pnlCustomFieldValues);

            Theming.ApplyTheme(Controls);
            Theming.ApplyTheme(components?.Components);
        }

        public override void SetData(Models.Lead data) {
            this.Tag = data;
            txtID.Text = data.ID.ToString();
            txtLink.Text = data.Link;
            if (users.ContainsKey(data.CreatorID))
                txtCreator.Text = users[data.CreatorID];
            txtCreatedAt.Text = data.CreatedAt;
            txtUpdatedAt.Text = data.UpdatedAt;
            cbxOwner.Text = data.OwnerID.HasValue ? users[data.OwnerID.Value] : null;
            txtFirstName.Text = data.FirstName;
            txtLastName.Text = data.LastName;
            txtCompany.Text = data.OrganizationName;
            txtStatus.Text = data.Status;
            if (data.SourceID.HasValue)
                cbxSource.Text = sources[data.SourceID.Value];
            else
                cbxSource.SelectedIndex = 0;
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
            txtTags.Text = string.Join(',', data.Tags);
            txtTags.Tag = data.Tags;

            ZendeskPropertyGridMethods.SetCustomFieldValues(customFields, customFieldControls, data.CustomFields);
        }

        public override Models.Lead GetData() {
            var rtn = new Models.Lead() {
                ID = (this.Tag as Models.Lead ?? new Models.Lead()).ID,

                OwnerID = users.ContainsValue(cbxOwner.Text) ? users.First(kv => kv.Value == cbxOwner.Text).Key : (int?)null,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                OrganizationName = txtCompany.Text,
                Status = txtStatus.Text,
                SourceID = sources.ContainsValue(cbxSource.Text) ? sources.First(kv => kv.Value == cbxSource.Text).Key : (int?)null,
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
                Tags = txtTags.Tag as IEnumerable<string> ?? new string[0]
            };

            rtn.CustomFields = ZendeskPropertyGridMethods.GetCustomFieldValues(customFields, customFieldControls);

            return rtn;
        }
    }
}
