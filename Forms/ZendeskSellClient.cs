using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Controls;
using Helpers;

namespace Forms {
    public partial class ZendeskSellClient : Form {
        public ZendeskSellClient() {
            InitializeComponent();
            lstItems.DoubleBuffered(true);
            ApplyTheme();
        }

        public void ApplyTheme() {
            Theming.ApplyTheme(this);
            if (components != null)
                Theming.ApplyTheme(components.Components);
        }

        private void ZendeskSellClient_Shown(object sender, EventArgs e) {
            btnSettings.PerformClick();
        }

        private void btnSettings_Click(object _, EventArgs __) {
            var inputDialog = new Ookii.Dialogs.InputDialog() {
                MainInstruction = "Input Access Token:",
                WindowTitle = "Zendesk Sell Token"
            };
            if (inputDialog.ShowDialog() == DialogResult.OK)
                sellClient = new ZendeskSell.ZendeskSellClient(inputDialog.Input);
        }

        private ZendeskSell.IZendeskSellClient sellClient;
        private IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> leadCustomFields;
        private IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> contactCustomFields;
        private IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> dealCustomFields;
        private Dictionary<int, string> users;
        private Dictionary<int, string> leadSources;
        private Dictionary<int, string> dealSources;
        private Dictionary<int, string> dealStages;
        private Dictionary<int, string> dealLossReasons;
        private Dictionary<int, string> dealUnqualifiedReasons;
        private Dictionary<int, string> products;

        private async void cbxType_SelectedIndexChanged(object sender, EventArgs e) {
            cbxType.Enabled = false;
            grpMain.Enabled = false;

            lstItems.Items.Clear();

            try {
                users = (await ZendeskGet.GetAll((pn, pc) => sellClient.Users.GetAsync(pn, pc))).ToDictionary(u => u.ID, u => u.Name);

                switch (cbxType.Text) {
                    case "Leads":
                        leadCustomFields = await ZendeskGet.GetAll((pn, pc) => sellClient.CustomFields.GetLeads());
                        leadSources = (await ZendeskGet.GetAll((pn, pc) => sellClient.LeadSources.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        SetPropertyGrid(new LeadPropertyGrid(leadCustomFields, users, leadSources));
                        break;
                    case "Contacts":
                        contactCustomFields = await ZendeskGet.GetAll((pn, pc) => sellClient.CustomFields.GetContacts());
                        SetPropertyGrid(new ContactPropertyGrid(contactCustomFields, users));
                        break;
                    case "Deals":
                        dealCustomFields = await ZendeskGet.GetAll((pn, pc) => sellClient.CustomFields.GetDeals());
                        dealSources = (await ZendeskGet.GetAll((pn, pc) => sellClient.DealSources.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        dealStages = (await ZendeskGet.GetAll((pn, pc) => sellClient.Stages.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        dealLossReasons = (await ZendeskGet.GetAll((pn, pc) => sellClient.DealLossReasons.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        dealUnqualifiedReasons = (await ZendeskGet.GetAll((pn, pc) => sellClient.DealUnqualifiedReasons.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        var contacts = (await ZendeskGet.GetAll((pn, pc) => sellClient.Contacts.GetAsync(pn, pc))).ToDictionary(c => c.ID, c => c.Name);
                        SetPropertyGrid(new DealPropertyGrid(dealCustomFields, users, contacts, dealSources, dealStages, dealLossReasons, dealUnqualifiedReasons));
                        break;
                }
                grpMain.Enabled = true;
            } finally {
                cbxType.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }


        private void SetPropertyGrid<T>(IZendeskPropertyGrid<T> grid) where T : Models.Base {
            if (scMain.Panel2.Tag != null)
                scMain.Panel2.Controls.RemoveAt(0);

            grid.Dock = DockStyle.Fill;
            scMain.Panel2.Tag = grid;
            scMain.Panel2.Controls.Add(grid);
        }
        private IZendeskPropertyGrid<T> GetPropertyGrid<T>() where T : Models.Base =>
            (IZendeskPropertyGrid<T>)scMain.Panel2.Tag;

        private ListViewItem UpdateItem(ListViewItem item, Models.Base data) {
            item.Tag = data;
            item.Text = data.ID.ToString();
            item.SubItems[1].Text = data.Name;
            item.SubItems[2].Text = users[data.OwnerID.Value];

            return item;
        }
        private ListViewItem CreateItem(Models.Base data) =>
            UpdateItem(new ListViewItem(new string[3]), data);
        private Models.Base GetData(ListViewItem item) =>
            (Models.Base)item.Tag;


        private async void btnGetAll_Click(object sender, EventArgs e) {
            btnGetAll.Enabled = false;
            IEnumerable<Models.Base> items = null;

            try {
                switch (cbxType.Text) {
                    case "Leads":
                        items = (await ZendeskGet.GetAll((pn, pc) => sellClient.Leads.GetAsync(pn, pc))).Select(Converter.Convert);
                        break;
                    case "Contacts":
                        items = (await ZendeskGet.GetAll((pn, pc) => sellClient.Contacts.GetAsync(pn, pc))).Select(Converter.Convert);
                        break;
                    case "Deals":
                        items = (await ZendeskGet.GetAll((pn, pc) => sellClient.Deals.GetAsync(pn, pc))).Select(Converter.Convert);
                        break;
                }

                lstItems.Items.Clear();
                lstItems.Items.AddRange(items.Select(CreateItem).ToArray());
                lstItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            } finally {
                btnGetAll.Enabled = true;
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstItems.SelectedItems.Count != 1)
                return;

            var item = GetData(lstItems.SelectedItems[0]);
            numOneID.Value = item.ID;
            switch (cbxType.Text) {
                case "Leads":
                    GetPropertyGrid<Models.Lead>().SetData((Models.Lead)item);
                    break;
                case "Contacts":
                    GetPropertyGrid<Models.Contact>().SetData((Models.Contact)item);
                    break;
                case "Deals":
                    GetPropertyGrid<Models.Deal>().SetData((Models.Deal)item);
                    break;
            }
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnGetOne_Click(object sender, EventArgs e) {

        }

        private void btnCreate_Click(object sender, EventArgs e) {

        }

        private void btnUpdate_Click(object sender, EventArgs e) {

        }

        private void btnDelete_Click(object sender, EventArgs e) {

        }
    }
}
