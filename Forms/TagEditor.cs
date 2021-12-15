using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Helpers;

namespace Forms {
    public partial class TagEditor : Form {
        public TagEditor(Settings settings, IEnumerable<string> tags) : this(settings) => Tags = tags;
        public TagEditor(Settings settings) {
            InitializeComponent();
            this.Icon = Properties.Resources.ZendeskSell;

            ApplyTheme(settings.GetTheme());
            settings.ThemeChanged += ApplyTheme;
        }

        void ApplyTheme(WalkmanLib.Theme theme) {
            Theming.ApplyTheme(theme, this);
            Theming.ApplyTheme(theme, components?.Components);
        }

        public IEnumerable<string> Tags {
            get => txtTags.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            set => txtTags.Text = string.Join(Environment.NewLine, value);
        }
    }
}
