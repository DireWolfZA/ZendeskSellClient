using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Forms {
    public partial class TagEditor : Form {
        public TagEditor(IEnumerable<string> tags) : this() => Tags = tags;
        public TagEditor() {
            InitializeComponent();
            ZendeskSellClient.ApplyTheme(this);
        }

        public IEnumerable<string> Tags {
            get => txtTags.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            set => txtTags.Text = string.Join(Environment.NewLine, value);
        }
    }
}
