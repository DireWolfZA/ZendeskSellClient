using System.Windows.Forms;
using ZendeskSell.Models;

namespace Forms {
    public partial class AddressEditor : Form {
        public AddressEditor(Address address) : this() => Address = address;
        public AddressEditor() {
            InitializeComponent();
            ZendeskSellClient.ApplyTheme(this);
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
