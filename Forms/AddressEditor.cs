using System.Windows.Forms;
using Helpers;
using ZendeskSell.Models;

namespace Forms {
    public partial class AddressEditor : Form {
        public AddressEditor(Settings settings, Address address) : this(settings) => Address = address;
        public AddressEditor(Settings settings) {
            InitializeComponent();
            this.Icon = Properties.Resources.ZendeskSell;

            ApplyTheme(settings.GetTheme());
            settings.ThemeChanged += ApplyTheme;
        }

        void ApplyTheme(WalkmanLib.Theme theme) {
            Theming.ApplyTheme(theme, this);
            Theming.ApplyTheme(theme, components?.Components);
        }

        public Address Address {
            get => new Address() {
                Line1 = string.IsNullOrWhiteSpace(txtLine1.Text) ? null : txtLine1.Text,
                City = string.IsNullOrWhiteSpace(txtCity.Text) ? null : txtCity.Text,
                State = string.IsNullOrWhiteSpace(txtState.Text) ? null : txtState.Text,
                PostalCode = string.IsNullOrWhiteSpace(txtPostalCode.Text) ? null : txtPostalCode.Text,
                Country = string.IsNullOrWhiteSpace(txtCountry.Text) ? null : txtCountry.Text
            };
            set {
                txtLine1.Text = value.Line1;
                txtCity.Text = value.City;
                txtState.Text = value.State;
                txtPostalCode.Text = value.PostalCode;
                txtCountry.Text = value.Country;
            }
        }
    }
}
