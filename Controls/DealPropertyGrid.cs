using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helpers;

namespace Controls {
    public partial class DealPropertyGrid : IZendeskPropertyGrid<Models.Deal> {
        private readonly IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields;
        private readonly Dictionary<int, string> users;
        private readonly Dictionary<long, string> contacts;
        private readonly Dictionary<int, string> sources;
        private readonly Dictionary<int, string> stages;
        private readonly Dictionary<int, string> lossReasons;
        private readonly Dictionary<int, string> unqualifiedReasons;
        private readonly Dictionary<string, Control> customFieldControls = new Dictionary<string, Control>();

        public DealPropertyGrid(Forms.Settings settings, IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields, Dictionary<int, string> users,
                                Dictionary<long, string> contacts, Dictionary<int, string> sources, Dictionary<int, string> stages,
                                Dictionary<int, string> lossReasons, Dictionary<int, string> unqualifiedReasons) {
            this.customFields = customFields;
            this.users = users;
            this.contacts = contacts;
            this.sources = sources;
            this.stages = stages;
            this.lossReasons = lossReasons;
            this.unqualifiedReasons = unqualifiedReasons;

            InitializeComponent();
            txtLink.LinkClicked += ZendeskPropertyGridMethods.LinkLabel_LinkClicked;
            btnTagsEdit.Click += (s, e) => ZendeskPropertyGridMethods.TagEditButton_Click(settings, txtTags);

            scMain.Tag = false;
            scMain.Panel1.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel1_Scroll(scMain);
            scMain.Panel2.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel2_Scroll(scMain);

            cbxOwner.Items.Clear();
            cbxOwner.Items.AddRange(users.Values.ToArray());
            cbxContact.Items.Clear();
            cbxContact.Items.AddRange(contacts.Values.ToArray());
            cbxSource.Items.Clear();
            cbxSource.Items.Add("");
            cbxSource.Items.AddRange(sources.Values.ToArray());
            cbxStage.Items.Clear();
            cbxStage.Items.AddRange(stages.Values.ToArray());
            cbxLossReason.Items.Clear();
            cbxLossReason.Items.Add("");
            cbxLossReason.Items.AddRange(lossReasons.Values.ToArray());
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

        public override void SetData(Models.Deal data) {
            this.Tag = data;
            txtID.Text = data.ID.ToString();
            txtLink.Text = data.Link;
            txtCreator.Text = users.ContainsKey(data.CreatorID) ? users[data.CreatorID] : null;
            txtCreatedAt.Text = data.CreatedAt;
            txtUpdatedAt.Text = data.UpdatedAt;
            txtLastActivityAt.Text = data.LastActivityAt;
            txtLastStageChangeBy.Text = data.LastStageChangeByID.HasValue ? users[data.LastStageChangeByID.Value] : null;
            txtDropboxEmail.Text = data.DropboxEmail;
            txtOrganization.Text = data.OrganizationID.HasValue ? contacts[data.OrganizationID.Value] : null;

            cbxOwner.Text = data.OwnerID.HasValue ? users[data.OwnerID.Value] : null;
            cbxContact.Text = contacts.ContainsKey(data.ContactID) ? contacts[data.ContactID] : null;
            if (data.SourceID.HasValue)
                cbxSource.Text = sources[data.SourceID.Value];
            else
                cbxSource.SelectedIndex = 0;
            txtName.Text = data.Name;
            txtCurrency.Text = data.Currency;
            txtValue.Text = data.Value;
            cbxStage.Text = data.StageID.HasValue ? stages[data.StageID.Value] : null;
            chkHot.Checked = data.Hot;
            txtLastStageChangeAt.Text = data.LastStageChangeAt;
            txtAddedAt.Text = data.AddedAt;
            if (data.LossReasonID.HasValue)
                cbxLossReason.Text = lossReasons[data.LossReasonID.Value];
            else
                cbxLossReason.SelectedIndex = 0;
            if (data.UnqualifiedReasonID.HasValue)
                cbxUnqualifiedReason.Text = unqualifiedReasons[data.UnqualifiedReasonID.Value];
            else
                cbxUnqualifiedReason.SelectedIndex = 0;
            txtEstimatedCloseDate.Text = data.EstimatedCloseDate;
            txtCustomizedWinLikelihood.Text = data.CustomizedWinLikelihood.ToString();
            txtTags.Text = string.Join(',', data.Tags);
            txtTags.Tag = data.Tags;

            ZendeskPropertyGridMethods.SetCustomFieldValues(customFields, customFieldControls, data.CustomFields);
        }

        public override Models.Deal GetData() {
            var rtn = new Models.Deal() {
                ID = (this.Tag as Models.Deal ?? new Models.Deal()).ID,

                OwnerID = users.ContainsValue(cbxOwner.Text) ? users.First(kv => kv.Value == cbxOwner.Text).Key : (int?)null,
                ContactID = contacts.ContainsValue(cbxContact.Text) ? contacts.First(kv => kv.Value == cbxContact.Text).Key : 0,
                SourceID = sources.ContainsValue(cbxSource.Text) ? sources.First(kv => kv.Value == cbxSource.Text).Key : (int?)null,
                Name = txtName.Text,
                Currency = txtCurrency.Text,
                Value = txtValue.Text,
                StageID = stages.ContainsValue(cbxStage.Text) ? stages.First(kv => kv.Value == cbxStage.Text).Key : (int?)null,
                Hot = chkHot.Checked,
                LastStageChangeAt = txtLastStageChangeAt.Text,
                AddedAt = txtAddedAt.Text,
                LossReasonID = lossReasons.ContainsValue(cbxLossReason.Text) ? lossReasons.First(kv => kv.Value == cbxLossReason.Text).Key : (int?)null,
                UnqualifiedReasonID = unqualifiedReasons.ContainsValue(cbxUnqualifiedReason.Text) ? unqualifiedReasons.First(kv => kv.Value == cbxUnqualifiedReason.Text).Key : (int?)null,
                EstimatedCloseDate = txtEstimatedCloseDate.Text,
                CustomizedWinLikelihood = string.IsNullOrWhiteSpace(txtCustomizedWinLikelihood.Text) ? (int?)null : int.Parse(txtCustomizedWinLikelihood.Text),
                Tags = txtTags.Tag as IEnumerable<string> ?? new string[0]
            };

            rtn.CustomFields = ZendeskPropertyGridMethods.GetCustomFieldValues(customFields, customFieldControls);

            return rtn;
        }
    }
}
