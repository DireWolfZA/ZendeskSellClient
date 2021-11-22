using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Helpers;

namespace Forms {
    public partial class Settings : Form {
        // essentially VB.Net's auto default form instance but for C#. see https://stackoverflow.com/a/4699360/2999220
        [ThreadStatic]
        private static Settings instance;
        public Settings() {
            InitializeComponent();
            instance = this;
        }
        public static Settings I {
            get {
                if (instance == null) {
                    instance = new Settings();
                    instance.FormClosed += delegate { instance = null; };
                }
                return instance;
            }
        }

        private string _settingsPath;
        public bool Loaded { get; private set; } = false;

        public void Init() {
            string configFileName = "ZendeskSellClient.xml";
            if (Environment.GetEnvironmentVariable("OS") == "Windows_NT") {
                if (!Directory.Exists(Path.Combine(Environment.GetEnvironmentVariable("AppData"), "WalkmanOSS")))
                    Directory.CreateDirectory(Path.Combine(Environment.GetEnvironmentVariable("AppData"), "WalkmanOSS"));
                _settingsPath = Path.Combine(Environment.GetEnvironmentVariable("AppData"), "WalkmanOSS", configFileName);
            } else {
                if (!Directory.Exists(Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".config", "WalkmanOSS")))
                    Directory.CreateDirectory(Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".config", "WalkmanOSS"));
                _settingsPath = Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".config", "WalkmanOSS", configFileName);
            }

            if (File.Exists(Path.Combine(Application.StartupPath, configFileName))) {
                _settingsPath = Path.Combine(Application.StartupPath, configFileName);
            } else if (File.Exists(configFileName)) {
                _settingsPath = new FileInfo(configFileName).FullName;
            }

            cbxTheme.Items.AddRange(Enum.GetNames(typeof(ThemeNames)));

            Loaded = true;
            if (File.Exists(_settingsPath)) {
                LoadSettings();
            } else {
                // set initial settings
                cbxTheme.SelectedIndex = 0;
                chkAutoGetAll.Checked = true;
            }
        }

        private void this_VisibleChanged(object _, EventArgs __) {
            if (this.Visible)
                this.CenterToParent();
        }

        public enum ThemeNames {
            Default,
            Inverted,
            SystemDark,
            Dark,
            Test
        }

        public WalkmanLib.Theme GetTheme() {
            switch (Theme) {
                case ThemeNames.Default:
                    return WalkmanLib.Theme.Default;
                case ThemeNames.Inverted:
                    return WalkmanLib.Theme.Inverted;
                case ThemeNames.SystemDark:
                    return WalkmanLib.Theme.SystemDark;
                case ThemeNames.Dark:
                    return WalkmanLib.Theme.Dark;
                case ThemeNames.Test:
                    return WalkmanLib.Theme.Test;
                default:
                    throw new ApplicationException("Invalid Theme Name: " + Theme.ToString());
            }
        }

        public void ApplyTheme() {
            Theming.ApplyTheme(this);
            Theming.ApplyTheme(components?.Components);
            ZendeskSellClient.I.ApplyTheme();
        }

        #region Properties
        public string AccessToken { get; private set; }
        public ThemeNames Theme { get; private set; }
        public bool AutoGetAll { get; private set; }
        #endregion

        #region GUI Methods
        private void txtAccessToken_TextChanged(object _, EventArgs __) {
            AccessToken = txtAccessToken.Text;
            SaveSettings();
            ZendeskSellClient.I.AccessTokenChanged(AccessToken);
        }
        private void cbxTheme_SelectedIndexChanged(object _, EventArgs __) {
            Theme = (ThemeNames)cbxTheme.SelectedIndex;
            SaveSettings();
            ApplyTheme();
        }
        private void chkAutoGetAll_CheckedChanged(object _, EventArgs __) {
            AutoGetAll = chkAutoGetAll.Checked;
            SaveSettings();
        }

        private void btnClose_Click(object _, EventArgs __) {
            this.Hide();
        }
        private void btnShowSettingsFile_Click(object _, EventArgs __) {
            switch (WalkmanLib.GetOS()) {
                case WalkmanLib.OS.Windows:
                    Process.Start("explorer.exe", "/select, " + _settingsPath);
                    break;
                case WalkmanLib.OS.Linux:
                    Process.Start("xdg-open", Path.GetDirectoryName(_settingsPath));
                    break;
                case WalkmanLib.OS.MacOS:
                    Process.Start("open", $"-R \"{_settingsPath}\"");
                    break;
            }
        }
        #endregion

        #region Settings Saving & Loading
        private void LoadSettings(object _, EventArgs __) => LoadSettings();
        private void LoadSettings() {
            if (!Loaded)
                return;
            _loading = true;
            try {
                using (var reader = XmlReader.Create(_settingsPath)) {
                    try {
                        reader.Read();
                    } catch (XmlException) {
                        return;
                    }

                    if (reader.IsStartElement() && reader.Name == "ZendeskSellClient") {
                        if (reader.Read() && reader.IsStartElement() && reader.Name == "Settings" && reader.Read()) {
                            while (reader.IsStartElement()) {
                                switch (reader.Name ?? "") {
                                    case "AccessToken": {
                                        reader.Read();
                                        txtAccessToken.Text = reader.Value.Trim();
                                        break;
                                    }
                                    case "Theme": {
                                        reader.Read();
                                        Enum.TryParse(reader.Value, out ThemeNames var);
                                        cbxTheme.SelectedIndex = (int)var;
                                        break;
                                    }
                                    case "AutoGetAll": {
                                        reader.Read();
                                        bool.TryParse(reader.Value, out bool var);
                                        chkAutoGetAll.Checked = var;
                                        break;
                                    }
                                    default: {
                                        reader.Read(); // skip unknown values
                                        break;
                                    }
                                }

                                reader.Read();
                                reader.Read();
                            }
                        }
                    }
                }
            } finally {
                _loading = false;
            }
        }

        private bool _loading = false; // so that we don't save while loading settings

        private void SaveSettings(object _, EventArgs __) => SaveSettings();
        internal void SaveSettings() {
            if (!Loaded || _loading)
                return;
            using (var writer = XmlWriter.Create(_settingsPath, new XmlWriterSettings() { Indent = true })) {
                writer.WriteStartDocument();
                writer.WriteStartElement("ZendeskSellClient");
                writer.WriteStartElement("Settings");

                writer.WriteElementString("AccessToken", AccessToken);
                writer.WriteElementString("Theme", Theme.ToString());
                writer.WriteElementString("AutoGetAll", AutoGetAll.ToString());

                writer.WriteEndElement(); // Settings
                writer.WriteEndElement(); // ZendeskSellClient
                writer.WriteEndDocument();
            }
        }
        #endregion
    }
}
