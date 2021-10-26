using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Forms {
    public partial class ZendeskSellClient : Form {
        public ZendeskSellClient() {
            InitializeComponent();

            ApplyTheme();
        }

        void ApplyTheme() {
            var theme = WalkmanLib.Theme.Dark;
            ApplyTheme(this);
            if (components != null)
                ApplyTheme(components.Components);
            ToolStripManager.Renderer = new WalkmanLib.CustomPaint.ToolStripSystemRendererWithDisabled(theme.ToolStripItemDisabledText);
        }
        public static void ApplyTheme(Form form) {
            var theme = WalkmanLib.Theme.Dark;
            WalkmanLib.ApplyTheme(theme, form, true);
        }
        public static void ApplyTheme(System.Collections.IEnumerable controls) {
            var theme = WalkmanLib.Theme.Dark;
            WalkmanLib.ApplyTheme(theme, controls, true);
        }

    }
}
