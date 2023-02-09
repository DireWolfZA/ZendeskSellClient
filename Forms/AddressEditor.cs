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
                Line1 = txtLine1.Text.EmptyToNull(),
                City = txtCity.Text.EmptyToNull(),
                State = txtState.Text.EmptyToNull(),
                PostalCode = txtPostalCode.Text.EmptyToNull(),
                Country = txtCountry.Text.EmptyToNull()
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
