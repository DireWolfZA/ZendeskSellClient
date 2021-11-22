using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Helpers;

namespace Forms {
    public partial class TagEditor : Form {
        public TagEditor(IEnumerable<string> tags) : this() => Tags = tags;
        public TagEditor() {
            InitializeComponent();
            this.Icon = Properties.Resources.ZendeskSell;

            Theming.ApplyTheme(this);
            Theming.ApplyTheme(components?.Components);
        }

        public IEnumerable<string> Tags {
            get => txtTags.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            set => txtTags.Text = string.Join(Environment.NewLine, value);
        }
    }
}
