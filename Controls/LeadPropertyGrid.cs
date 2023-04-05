using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helpers;

namespace Controls {
    public partial class LeadPropertyGrid : IZendeskPropertyGrid<Models.Lead> {
        private readonly IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields;
        private readonly Dictionary<int, string> users;
        private readonly Dictionary<int, string> sources;
        private readonly Dictionary<int, string> unqualifiedReasons;

        private readonly Dictionary<string, Control> customFieldControls = new Dictionary<string, Control>();

        public LeadPropertyGrid(Forms.Settings settings, IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields,
                                Dictionary<int, string> users, Dictionary<int, string> sources, Dictionary<int, string> unqualifiedReasons) {
            this.customFields = customFields;
            this.users = users;
            this.sources = sources;
            this.unqualifiedReasons = unqualifiedReasons;

            InitializeComponent();
            txtLink.LinkClicked += ZendeskPropertyGridMethods.LinkLabel_LinkClicked;
            btnAddressEdit.Click += (s, e) => ZendeskPropertyGridMethods.AddressEditButton_Click(settings, txtAddress);
            btnTagsEdit.Click += (s, e) => ZendeskPropertyGridMethods.TagEditButton_Click(settings, txtTags);

            scMain.Tag = false;
            scMain.Panel1.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel1_Scroll(scMain);
            scMain.Panel2.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel2_Scroll(scMain);

            cbxOwner.Items.Clear();
            cbxOwner.Items.AddRange(users.Values.ToArray());
            cbxSource.Items.Clear();
            cbxSource.Items.Add("");
            cbxSource.Items.AddRange(sources.Values.ToArray());
            cbxUnqualifiedReason.Items.Clear();
            cbxUnqualifiedReason.Items.Add("");
            cbxUnqualifiedReason.Items.AddRange(unqualifiedReasons.Values.ToArray());

            ZendeskPropertyGridMethods.CreateCustomFields(customFields, customFieldControls, pnlCustomFieldLabels, pnlCustomFieldValues);

            ApplyTheme(settings.GetTheme());
            settings.ThemeChanged += ApplyTheme;
        }

        public override void ApplyTheme(WalkmanLib.Theme theme) {
            Theming.ApplyTheme(theme, Controls);
            Theming.ApplyTheme(theme, components?.Components);
        }

        public override void SetData(Models.Lead data) {
            this.Tag = data;
            txtID.Text = data.ID.ToString();
            txtLink.Text = data.Link;
            txtCreator.Text = users.ContainsKey(data.CreatorID) ? users[data.CreatorID] : null;
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
            if (data.UnqualifiedReasonID.HasValue)
                cbxUnqualifiedReason.Text = unqualifiedReasons[data.UnqualifiedReasonID.Value];
            else
                cbxUnqualifiedReason.SelectedIndex = 0;
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
                UnqualifiedReasonID = unqualifiedReasons.ContainsValue(cbxUnqualifiedReason.Text) ? unqualifiedReasons.First(kv => kv.Value == cbxUnqualifiedReason.Text).Key : (int?)null,
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

        public override Models.Lead ApplyUpdate(Models.Lead data) {
            if (users.ContainsValue(cbxOwner.Text))
                data.OwnerID = users.First(kv => kv.Value == cbxOwner.Text).Key;
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                data.FirstName = txtFirstName.Text;
            if (!string.IsNullOrWhiteSpace(txtLastName.Text))
                data.LastName = txtLastName.Text;
            if (!string.IsNullOrWhiteSpace(txtCompany.Text))
                data.OrganizationName = txtCompany.Text;
            if (!string.IsNullOrWhiteSpace(txtStatus.Text))
                data.Status = txtStatus.Text;
            if (sources.ContainsValue(cbxSource.Text))
                data.SourceID = sources.First(kv => kv.Value == cbxSource.Text).Key;
            if (unqualifiedReasons.ContainsValue(cbxUnqualifiedReason.Text))
                data.UnqualifiedReasonID = unqualifiedReasons.First(kv => kv.Value == cbxUnqualifiedReason.Text).Key;
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
            if (!string.IsNullOrWhiteSpace(string.Concat(txtTags.Tag as IEnumerable<string> ?? Enumerable.Empty<string>())?.Trim()))
                data.Tags = txtTags.Tag as IEnumerable<string>;

            data.CustomFields = ZendeskPropertyGridMethods.ApplyCustomFieldValues(customFields, customFieldControls, data.CustomFields);

            return data;
        }
    }
}
