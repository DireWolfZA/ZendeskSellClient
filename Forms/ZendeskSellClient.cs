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

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e) {

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


        private void btnGetAll_Click(object sender, EventArgs e) {

        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e) {

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
