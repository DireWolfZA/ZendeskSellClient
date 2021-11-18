using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
