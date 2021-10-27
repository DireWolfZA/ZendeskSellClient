using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controls {
    public partial class LeadPropertyGrid : UserControl, IZendeskPropertyGrid<Models.Lead> {
        private readonly IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields;
        private readonly Dictionary<int, string> users;
        private readonly Dictionary<int, string> sources;

        public LeadPropertyGrid(IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields, Dictionary<int, string> users, Dictionary<int, string> sources) {
            this.customFields = customFields;
            this.users = users;
            this.sources = sources;

            InitializeComponent();
            txtLink.LinkClicked += ZendeskPropertyGridMethods.LinkLabel_LinkClicked;

            scMain.Tag = false;
            scMain.Panel1.Scroll += new ScrollEventHandler((s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel1_Scroll(scMain));
            scMain.Panel2.Scroll += new ScrollEventHandler((s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel2_Scroll(scMain));

            cbxOwner.Items.Clear();
            cbxOwner.Items.AddRange(users.Values.ToArray());
            cbxSource.Items.Clear();
            cbxSource.Items.Add("");
            cbxSource.Items.AddRange(sources.Values.ToArray());

            Forms.ZendeskSellClient.ApplyTheme(Controls);
        }

        public void SetData(Models.Lead data) {
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
            txtAddress.Text = data.Address.ToTextOneLine();
            txtAddress.Tag = data.Address;
            txtTags.Text = string.Join(',', data.Tags);
            txtTags.Tag = data.Tags;
        }

        public Models.Lead GetData() {
        }
    }
}
