using System.Collections.Generic;
using System.Linq;
using Helpers;

namespace Controls {
    public partial class LineItemPropertyGrid : IZendeskPropertyGrid<Models.LineItem> {
        private readonly Dictionary<int, string> products;

        public LineItemPropertyGrid(Dictionary<int, string> products) {
            this.products = products;

            InitializeComponent();

            scMain.Tag = false;
            scMain.Panel1.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel1_Scroll(scMain);
            scMain.Panel2.Scroll += (s, e) => ZendeskPropertyGridMethods.SplitContainer_Panel2_Scroll(scMain);

            cbxProduct.Items.Clear();
            cbxProduct.Items.Add("");
            cbxProduct.Items.AddRange(products.Values.ToArray());

            Theming.ApplyTheme(Controls);
            if (components != null)
                Theming.ApplyTheme(components.Components);
        }

        public override void SetData(Models.LineItem data) {
            this.Tag = data;
            txtID.Text = data.ID.ToString();
            txtCreatedAt.Text = data.CreatedAt;
            txtUpdatedAt.Text = data.UpdatedAt;
            txtName.Text = data.Name;
            txtSKU.Text = data.SKU;
            txtDescription.Text = data.Description;
            txtPrice.Text = data.Price;

            txtDiscount.Text = data.Discount.ToString();
            if (data.ProductID.HasValue)
                cbxProduct.Text = products[data.ProductID.Value];
            else
                cbxProduct.SelectedIndex = 0;
            txtValue.Text = data.Value;
            txtVariation.Text = data.Variation;
            txtCurrency.Text = data.Currency;
            numQuantity.Value = data.Quantity;
        }

        public override Models.LineItem GetData() {
            var rtn = new Models.LineItem() {
                ID = (this.Tag as Models.LineItem ?? new Models.LineItem()).ID,

                Discount = string.IsNullOrWhiteSpace(txtDiscount.Text) ? (int?)null : int.Parse(txtDiscount.Text),
                ProductID = products.ContainsValue(cbxProduct.Text) ? products.First(kv => kv.Value == cbxProduct.Text).Key : (int?)null,
                Value = txtValue.Text,
                Variation = txtVariation.Text,
                Currency = txtCurrency.Text,
                Quantity = (int)numQuantity.Value,
            };

            return rtn;
        }
    }
}
