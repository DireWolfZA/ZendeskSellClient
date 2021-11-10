using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helpers;

namespace Forms {
    public partial class ZendeskSellClient : Form {
        public ZendeskSellClient() {
            InitializeComponent();

            ApplyTheme();
        }

        void ApplyTheme() {
            Theming.ApplyTheme(this);
            if (components != null)
                Theming.ApplyTheme(components.Components);
        }
    }
}
