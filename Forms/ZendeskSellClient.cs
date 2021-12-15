using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Controls;
using Helpers;

namespace Forms {
    public partial class ZendeskSellClient : Form {
        private readonly Settings settings;
        private readonly StatusLabelManager labelManager;
        public ZendeskSellClient(Settings settings) {
            InitializeComponent();
            this.Icon = Properties.Resources.ZendeskSell;
            lstItems.DoubleBuffered(true);

            this.settings = settings;
            labelManager = new StatusLabelManager(statusLabel);

            settings.ThemeChanged += ApplyTheme;
            settings.AccessTokenChanged += AccessTokenChanged;
            settings.Init(); // this should apply the theme and set access token
        }

        private bool haveAddedCustomPaint = false;
        public void ApplyTheme(WalkmanLib.Theme theme) {
            if (!haveAddedCustomPaint) {
                Theming.AddListViewCustomPaint(lstItems);
                haveAddedCustomPaint = true;
            }
            lstItems.Tag = theme.ListViewColumnColors;

            Theming.ApplyTheme(theme, this);
            Theming.ApplyTheme(theme, components?.Components);
            GetPropertyGrid()?.ApplyTheme(theme);
        }

        private void ZendeskSellClient_Shown(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(settings.AccessToken))
                btnSettings.PerformClick();
        }

        private void btnSettings_Click(object _, EventArgs __) {
            settings.Show(this);
            settings.Activate();
            settings.BringToFront();
            settings.Focus();
        }

        public void AccessTokenChanged(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) {
                cbxType.Enabled = false;
                grpMain.Enabled = false;
            } else {
                cbxType.Enabled = true;
                sellClient = new ZendeskSell.ZendeskSellClient(accessToken);
            }
        }

        private ZendeskSell.IZendeskSellClient sellClient;
        private IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> leadCustomFields;
        private IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> contactCustomFields;
        private IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> dealCustomFields;
        private Dictionary<int, string> users;
        private Dictionary<int, string> leadSources;
        private Dictionary<int, string> leadUnqualifiedReasons;
        private Dictionary<int, string> dealSources;
        private Dictionary<int, string> dealStages;
        private Dictionary<int, string> dealLossReasons;
        private Dictionary<int, string> dealUnqualifiedReasons;
        private Dictionary<int, string> products;

        private async void btnRefresh_Click(object sender, EventArgs e) {
            cbxType.Enabled = false;
            btnRefresh.Enabled = false;
            grpMain.Enabled = false;

            lstItems.SelectedItems.Clear();
            if (scMain.Panel2.Tag != null)
                scMain.Panel2.Controls.RemoveAt(0);
            scMain.Panel2.Tag = null;

            try {
                using (labelManager.SetStatus("Getting Sell Users"))
                    users = (await ZendeskGet.GetAll((pn, pc) => sellClient.Users.GetAsync(pn, pc))).ToDictionary(u => u.ID, u => u.Name);

                switch (cbxType.Text) {
                    case "Leads":
                        using (labelManager.SetStatus("Getting Lead Custom Fields"))
                            leadCustomFields = await ZendeskGet.GetAll((pn, pc) => sellClient.CustomFields.GetLeads());
                        using (labelManager.SetStatus("Getting Lead Sources"))
                            leadSources = (await ZendeskGet.GetAll((pn, pc) => sellClient.LeadSources.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        using (labelManager.SetStatus("Getting Lead Unqualified Reasons"))
                            leadUnqualifiedReasons = (await ZendeskGet.GetAll((pn, pc) => sellClient.LeadUnqualifiedReasons.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        SetPropertyGrid(new LeadPropertyGrid(settings, leadCustomFields, users, leadSources, leadUnqualifiedReasons));
                        break;
                    case "Contacts":
                        using (labelManager.SetStatus("Getting Contact Custom Fields"))
                            contactCustomFields = await ZendeskGet.GetAll((pn, pc) => sellClient.CustomFields.GetContacts());
                        SetPropertyGrid(new ContactPropertyGrid(settings, contactCustomFields, users));
                        break;
                    case "Deals":
                        using (labelManager.SetStatus("Getting Deal Custom Fields"))
                            dealCustomFields = await ZendeskGet.GetAll((pn, pc) => sellClient.CustomFields.GetDeals());
                        using (labelManager.SetStatus("Getting Deal Sources"))
                            dealSources = (await ZendeskGet.GetAll((pn, pc) => sellClient.DealSources.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        using (labelManager.SetStatus("Getting Deal Stages"))
                            dealStages = (await ZendeskGet.GetAll((pn, pc) => sellClient.Stages.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        using (labelManager.SetStatus("Getting Deal Loss Reasons"))
                            dealLossReasons = (await ZendeskGet.GetAll((pn, pc) => sellClient.DealLossReasons.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        using (labelManager.SetStatus("Getting Deal Unqualified Reasons"))
                            dealUnqualifiedReasons = (await ZendeskGet.GetAll((pn, pc) => sellClient.DealUnqualifiedReasons.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        Dictionary<int, string> contacts;
                        using (labelManager.SetStatus("Getting Contacts"))
                            contacts = (await ZendeskGet.GetAll((pn, pc) => sellClient.Contacts.GetAsync(pn, pc))).ToDictionary(c => c.ID, c => c.Name);
                        SetPropertyGrid(new DealPropertyGrid(settings, dealCustomFields, users, contacts, dealSources, dealStages, dealLossReasons, dealUnqualifiedReasons));
                        break;
                    case "Line Items":
                        using (labelManager.SetStatus("Getting Products"))
                            products = (await ZendeskGet.GetAll((pn, pc) => sellClient.Products.GetAsync(pn, pc))).ToDictionary(p => p.ID, p => p.Name);
                        SetPropertyGrid(new LineItemPropertyGrid(settings, products));
                        break;
                }
            } finally {
                cbxType.Enabled = true;
                btnRefresh.Enabled = true;
                grpMain.Enabled = true;
            }
        }

        private async void cbxType_SelectedIndexChanged(object sender, EventArgs e) {
            cbxType.Enabled = false;
            btnRefresh.Enabled = false;
            grpMain.Enabled = false;

            lstItems.Items.Clear();
            if (scMain.Panel2.Tag != null)
                scMain.Panel2.Controls.RemoveAt(0);
            scMain.Panel2.Tag = null;

            if (cbxType.Text == "Line Items") {
                lblDealID.Visible = true;
                numDealID.Visible = true;
                btnUpdate.Visible = false;
                colHeadOwner.Text = "SKU";
            } else {
                lblDealID.Visible = false;
                numDealID.Visible = false;
                btnUpdate.Visible = true;
                colHeadOwner.Text = "Owner";
            }

            lstItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (settings.AutoRefreshDeps) {
                users = null;
                switch (cbxType.Text) {
                    case "Leads":
                        leadCustomFields = null;
                        leadSources = null;
                        leadUnqualifiedReasons = null;
                        break;
                    case "Contacts":
                        contactCustomFields = null;
                        break;
                    case "Deals":
                        dealCustomFields = null;
                        dealSources = null;
                        dealStages = null;
                        dealLossReasons = null;
                        dealUnqualifiedReasons = null;
                        break;
                    case "Line Items":
                        products = null;
                        break;
                }
            }

            try {
                if (users == null)
                    using (labelManager.SetStatus("Getting Sell Users"))
                        users = (await ZendeskGet.GetAll((pn, pc) => sellClient.Users.GetAsync(pn, pc))).ToDictionary(u => u.ID, u => u.Name);

                switch (cbxType.Text) {
                    case "Leads":
                        if (leadCustomFields == null)
                            using (labelManager.SetStatus("Getting Lead Custom Fields"))
                                leadCustomFields = await ZendeskGet.GetAll((pn, pc) => sellClient.CustomFields.GetLeads());
                        if (leadSources == null)
                            using (labelManager.SetStatus("Getting Lead Sources"))
                                leadSources = (await ZendeskGet.GetAll((pn, pc) => sellClient.LeadSources.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        if (leadUnqualifiedReasons == null)
                            using (labelManager.SetStatus("Getting Lead Unqualified Reasons"))
                                leadUnqualifiedReasons = (await ZendeskGet.GetAll((pn, pc) => sellClient.LeadUnqualifiedReasons.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        SetPropertyGrid(new LeadPropertyGrid(settings, leadCustomFields, users, leadSources, leadUnqualifiedReasons));
                        break;
                    case "Contacts":
                        if (contactCustomFields == null)
                            using (labelManager.SetStatus("Getting Contact Custom Fields"))
                                contactCustomFields = await ZendeskGet.GetAll((pn, pc) => sellClient.CustomFields.GetContacts());
                        SetPropertyGrid(new ContactPropertyGrid(settings, contactCustomFields, users));
                        break;
                    case "Deals":
                        if (dealCustomFields == null)
                            using (labelManager.SetStatus("Getting Deal Custom Fields"))
                                dealCustomFields = await ZendeskGet.GetAll((pn, pc) => sellClient.CustomFields.GetDeals());
                        if (dealSources == null)
                            using (labelManager.SetStatus("Getting Deal Sources"))
                                dealSources = (await ZendeskGet.GetAll((pn, pc) => sellClient.DealSources.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        if (dealStages == null)
                            using (labelManager.SetStatus("Getting Deal Stages"))
                                dealStages = (await ZendeskGet.GetAll((pn, pc) => sellClient.Stages.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        if (dealLossReasons == null)
                            using (labelManager.SetStatus("Getting Deal Loss Reasons"))
                                dealLossReasons = (await ZendeskGet.GetAll((pn, pc) => sellClient.DealLossReasons.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        if (dealUnqualifiedReasons == null)
                            using (labelManager.SetStatus("Getting Deal Unqualified Reasons"))
                                dealUnqualifiedReasons = (await ZendeskGet.GetAll((pn, pc) => sellClient.DealUnqualifiedReasons.GetAsync(pn, pc))).ToDictionary(s => s.ID, s => s.Name);
                        Dictionary<int, string> contacts;
                        using (labelManager.SetStatus("Getting Contacts"))
                            contacts = (await ZendeskGet.GetAll((pn, pc) => sellClient.Contacts.GetAsync(pn, pc))).ToDictionary(c => c.ID, c => c.Name);
                        SetPropertyGrid(new DealPropertyGrid(settings, dealCustomFields, users, contacts, dealSources, dealStages, dealLossReasons, dealUnqualifiedReasons));
                        break;
                    case "Line Items":
                        if (products == null)
                            using (labelManager.SetStatus("Getting Products"))
                                products = (await ZendeskGet.GetAll((pn, pc) => sellClient.Products.GetAsync(pn, pc))).ToDictionary(p => p.ID, p => p.Name);
                        SetPropertyGrid(new LineItemPropertyGrid(settings, products));
                        break;
                }
            } finally {
                cbxType.Enabled = true;
                btnRefresh.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            grpMain.Enabled = true;
            if (settings.AutoGetAll)
                btnGetAll.PerformClick();
        }


        private void SetPropertyGrid<T>(IZendeskPropertyGrid<T> grid) where T : Models.Base {
            grid.Dock = DockStyle.Fill;
            scMain.Panel2.Tag = grid;
            scMain.Panel2.Controls.Add(grid);
        }
        private IZendeskPropertyGrid GetPropertyGrid() =>
            (IZendeskPropertyGrid)scMain.Panel2.Tag;
        private IZendeskPropertyGrid<T> GetPropertyGrid<T>() where T : Models.Base =>
            (IZendeskPropertyGrid<T>)scMain.Panel2.Tag;

        private ListViewItem UpdateItem(ListViewItem item, Models.Base data) {
            item.Tag = data;
            item.Text = data.ID.ToString();
            item.SubItems[1].Text = data.Name;
            if (data.OwnerID.HasValue && users.ContainsKey(data.OwnerID.Value))
                item.SubItems[2].Text = users[data.OwnerID.Value];
            else if (data is Models.LineItem li)
                item.SubItems[2].Text = li.SKU;
            else
                item.SubItems[2].Text = data.OwnerID.ToString();

            return item;
        }
        private ListViewItem CreateItem(Models.Base data) =>
            UpdateItem(new ListViewItem(new string[3]), data);
        private Models.Base GetData(ListViewItem item) =>
            (Models.Base)item.Tag;

        private ListViewItem GetItem(int id) =>
            lstItems.Items.Cast<ListViewItem>().FirstOrDefault(d => GetData(d).ID == id);
        private ListViewItem AddOrUpdateData(Models.Base data) {
            var item = GetItem(data.ID);
            try { // just so I don't have to create a variable, resize columns, then return
                return item != null ? UpdateItem(item, data) : lstItems.Items.Add(CreateItem(data));
            } finally {
                lstItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }


        private async void btnGetAll_Click(object sender, EventArgs e) {
            btnGetAll.Enabled = false;
            IEnumerable<Models.Base> items = null;

            try {
                switch (cbxType.Text) {
                    case "Leads":
                        using (labelManager.SetStatus("Getting All Leads"))
                            items = (await ZendeskGet.GetAll((pn, pc) => sellClient.Leads.GetAsync(pn, pc))).Select(Converter.Convert);
                        break;
                    case "Contacts":
                        using (labelManager.SetStatus("Getting All Contacts"))
                            items = (await ZendeskGet.GetAll((pn, pc) => sellClient.Contacts.GetAsync(pn, pc))).Select(Converter.Convert);
                        break;
                    case "Deals":
                        using (labelManager.SetStatus("Getting All Deals"))
                            items = (await ZendeskGet.GetAll((pn, pc) => sellClient.Deals.GetAsync(pn, pc))).Select(Converter.Convert);
                        break;
                    case "Line Items":
                        ZendeskSell.Orders.OrderResponse order;
                        using (labelManager.SetStatus("Getting Order for DealID"))
                            order = await ZendeskGet.GetOrder(sellClient.Orders, (int)numDealID.Value);
                        using (labelManager.SetStatus("Getting Order's LineItems"))
                            items = (await ZendeskGet.GetAll((pn, pc) => sellClient.LineItems.GetAsync(order.ID, pn, pc))).Select(li => Converter.Convert(li, order));
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
            if (lstItems.SelectedItems.Count != 1) {
                SetPGEmptyData();
                return;
            }

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
                    numDealID.Value = item.ID;
                    GetPropertyGrid<Models.Deal>().SetData((Models.Deal)item);
                    break;
                case "Line Items":
                    GetPropertyGrid<Models.LineItem>().SetData((Models.LineItem)item);
                    break;
            }
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private async void btnGetOne_Click(object sender, EventArgs e) {
            btnGetOne.Enabled = false;
            int idToGet = (int)numOneID.Value;

            try {
                switch (cbxType.Text) {
                    case "Leads":
                        using (labelManager.SetStatus("Getting Lead")) {
                            Models.Lead lead = Converter.Convert(ZendeskGet.Handle(await sellClient.Leads.GetOneAsync(idToGet)));
                            GetPropertyGrid<Models.Lead>().SetData(lead);
                            AddOrUpdateData(lead).Selected = true;
                        }
                        break;
                    case "Contacts":
                        using (labelManager.SetStatus("Getting Contact")) {
                            Models.Contact contact = Converter.Convert(ZendeskGet.Handle(await sellClient.Contacts.GetOneAsync(idToGet)));
                            GetPropertyGrid<Models.Contact>().SetData(contact);
                            AddOrUpdateData(contact).Selected = true;
                        }
                        break;
                    case "Deals":
                        using (labelManager.SetStatus("Getting Deal")) {
                            Models.Deal deal = Converter.Convert(ZendeskGet.Handle(await sellClient.Deals.GetOneAsync(idToGet)));
                            GetPropertyGrid<Models.Deal>().SetData(deal);
                            AddOrUpdateData(deal).Selected = true;
                        }
                        break;
                    case "Line Items":
                        ZendeskSell.Orders.OrderResponse order;
                        using (labelManager.SetStatus("Getting Order for DealID"))
                            order = await ZendeskGet.GetOrder(sellClient.Orders, (int)numDealID.Value);
                        using (labelManager.SetStatus("Getting LineItem")) {
                            Models.LineItem lineitem = Converter.Convert(ZendeskGet.Handle(await sellClient.LineItems.GetOneAsync(order.ID, idToGet)), order);
                            GetPropertyGrid<Models.LineItem>().SetData(lineitem);
                            AddOrUpdateData(lineitem).Selected = true;
                        }
                        break;
                }
            } finally {
                btnGetOne.Enabled = true;
            }
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private async void btnUpdate_Click(object sender, EventArgs e) {
            btnUpdate.Enabled = false;

            try {
                switch (cbxType.Text) {
                    case "Leads":
                        var pgL = GetPropertyGrid<Models.Lead>();
                        using (labelManager.SetStatus("Updating Lead")) {
                            Models.Lead lead = Converter.Convert(ZendeskGet.Handle(await sellClient.Leads.UpdateAsync((int)numOneID.Value, Converter.Convert(pgL.GetData()))));
                            pgL.SetData(lead);
                            AddOrUpdateData(lead).Selected = true;
                        }
                        break;
                    case "Contacts":
                        var pgC = GetPropertyGrid<Models.Contact>();
                        using (labelManager.SetStatus("Updating Contact")) {
                            Models.Contact contact = Converter.Convert(ZendeskGet.Handle(await sellClient.Contacts.UpdateAsync((int)numOneID.Value, Converter.Convert(pgC.GetData()))));
                            pgC.SetData(contact);
                            AddOrUpdateData(contact).Selected = true;
                        }
                        break;
                    case "Deals":
                        var pgD = GetPropertyGrid<Models.Deal>();
                        using (labelManager.SetStatus("Updating Deal")) {
                            Models.Deal deal = Converter.Convert(ZendeskGet.Handle(await sellClient.Deals.UpdateAsync((int)numOneID.Value, Converter.Convert(pgD.GetData()))));
                            pgD.SetData(deal);
                            AddOrUpdateData(deal).Selected = true;
                        }
                        break;
                }
            } finally {
                btnUpdate.Enabled = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e) {
            btnDelete.Enabled = false;
            int idToDelete = (int)numOneID.Value;

            try {
                switch (cbxType.Text) {
                    case "Leads":
                        using (labelManager.SetStatus("Deleting Lead"))
                            ZendeskGet.Handle(await sellClient.Leads.DeleteAsync(idToDelete));
                        break;
                    case "Contacts":
                        using (labelManager.SetStatus("Deleting Contact"))
                            ZendeskGet.Handle(await sellClient.Contacts.DeleteAsync(idToDelete));
                        break;
                    case "Deals":
                        using (labelManager.SetStatus("Deleting Deal"))
                            ZendeskGet.Handle(await sellClient.Deals.DeleteAsync(idToDelete));
                        break;
                    case "Line Items":
                        ZendeskSell.Orders.OrderResponse order;
                        using (labelManager.SetStatus("Getting Order for DealID"))
                            order = await ZendeskGet.GetOrder(sellClient.Orders, (int)numDealID.Value);
                        using (labelManager.SetStatus("Deleting LineItem"))
                            ZendeskGet.Handle(await sellClient.LineItems.DeleteAsync(order.ID, idToDelete));
                        break;
                }
            } finally {
                btnDelete.Enabled = true;
            }
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            GetItem(idToDelete)?.Remove();
            SetPGEmptyData();
        }

        private void SetPGEmptyData() {
            switch (cbxType.Text) {
                case "Leads":
                    GetPropertyGrid<Models.Lead>().SetData(new Models.Lead());
                    break;
                case "Contacts":
                    GetPropertyGrid<Models.Contact>().SetData(new Models.Contact());
                    break;
                case "Deals":
                    GetPropertyGrid<Models.Deal>().SetData(new Models.Deal());
                    break;
                case "Line Items":
                    GetPropertyGrid<Models.LineItem>().SetData(new Models.LineItem());
                    break;
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e) {
            btnCreate.Enabled = false;

            try {
                switch (cbxType.Text) {
                    case "Leads":
                        var pgL = GetPropertyGrid<Models.Lead>();
                        using (labelManager.SetStatus("Creating Lead")) {
                            Models.Lead lead = Converter.Convert(ZendeskGet.Handle(await sellClient.Leads.CreateAsync(Converter.Convert(pgL.GetData()))));
                            pgL.SetData(lead);
                            numOneID.Value = lead.ID;
                            AddOrUpdateData(lead).Selected = true;
                        }
                        break;
                    case "Contacts":
                        var pgC = GetPropertyGrid<Models.Contact>();
                        using (labelManager.SetStatus("Creating Contact")) {
                            Models.Contact contact = Converter.Convert(ZendeskGet.Handle(await sellClient.Contacts.CreateAsync(Converter.Convert(pgC.GetData()))));
                            pgC.SetData(contact);
                            numOneID.Value = contact.ID;
                            AddOrUpdateData(contact).Selected = true;
                        }
                        break;
                    case "Deals":
                        using (labelManager.SetStatus("Creating Deal")) {
                            var pgD = GetPropertyGrid<Models.Deal>();
                            Models.Deal deal = Converter.Convert(ZendeskGet.Handle(await sellClient.Deals.CreateAsync(Converter.Convert(pgD.GetData()))));
                            pgD.SetData(deal);
                            numOneID.Value = deal.ID;
                            AddOrUpdateData(deal).Selected = true;
                        }
                        break;
                    case "Line Items":
                        // get existing or create order for deal
                        ZendeskSell.Orders.OrderResponse order;
                        using (labelManager.SetStatus("Getting Order for DealID"))
                            order = await ZendeskGet.GetOrder(sellClient.Orders, (int)numDealID.Value);
                        // get lineItem data to create
                        var pgI = GetPropertyGrid<Models.LineItem>();
                        // convert to ZendeskSellApi data
                        var (lineItemRequest, orderRequest) = Converter.Convert(pgI.GetData(), order);
                        // update order
                        using (labelManager.SetStatus("Updating Order for DealID"))
                            order = ZendeskGet.Handle(await sellClient.Orders.UpdateAsync(order.ID, orderRequest));
                        // create item and set PropertyGrid data
                        using (labelManager.SetStatus("Creating LineItem")) {
                            Models.LineItem lineItem = Converter.Convert(ZendeskGet.Handle(await sellClient.LineItems.CreateAsync(order.ID, lineItemRequest)), order);
                            pgI.SetData(lineItem);
                            numOneID.Value = lineItem.ID;
                            AddOrUpdateData(lineItem).Selected = true;
                        }
                        break;
                }
            } finally {
                btnCreate.Enabled = true;
            }
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}
