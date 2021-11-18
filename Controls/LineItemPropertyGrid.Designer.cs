namespace Controls {
    partial class LineItemPropertyGrid {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lblDescription = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.TextBox();
            this.lblCurrency = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.TextBox();
            this.lblVariation = new System.Windows.Forms.TextBox();
            this.lblSKU = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.TextBox();
            this.lblEditable = new System.Windows.Forms.Label();
            this.lblUpdatedAt = new System.Windows.Forms.TextBox();
            this.lblCreatedAt = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.TextBox();
            this.lblReadOnly = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbxProduct = new System.Windows.Forms.ComboBox();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtVariation = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtUpdatedAt = new System.Windows.Forms.TextBox();
            this.txtCreatedAt = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.AutoScroll = true;
            this.scMain.Panel1.Controls.Add(this.lblDescription);
            this.scMain.Panel1.Controls.Add(this.lblQuantity);
            this.scMain.Panel1.Controls.Add(this.lblCurrency);
            this.scMain.Panel1.Controls.Add(this.lblPrice);
            this.scMain.Panel1.Controls.Add(this.lblValue);
            this.scMain.Panel1.Controls.Add(this.lblVariation);
            this.scMain.Panel1.Controls.Add(this.lblSKU);
            this.scMain.Panel1.Controls.Add(this.lblName);
            this.scMain.Panel1.Controls.Add(this.lblProduct);
            this.scMain.Panel1.Controls.Add(this.lblDiscount);
            this.scMain.Panel1.Controls.Add(this.lblEditable);
            this.scMain.Panel1.Controls.Add(this.lblUpdatedAt);
            this.scMain.Panel1.Controls.Add(this.lblCreatedAt);
            this.scMain.Panel1.Controls.Add(this.lblID);
            this.scMain.Panel1.Controls.Add(this.lblReadOnly);
            this.scMain.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.AutoScroll = true;
            this.scMain.Panel2.Controls.Add(this.numQuantity);
            this.scMain.Panel2.Controls.Add(this.txtPrice);
            this.scMain.Panel2.Controls.Add(this.txtDescription);
            this.scMain.Panel2.Controls.Add(this.txtSKU);
            this.scMain.Panel2.Controls.Add(this.txtName);
            this.scMain.Panel2.Controls.Add(this.cbxProduct);
            this.scMain.Panel2.Controls.Add(this.txtCurrency);
            this.scMain.Panel2.Controls.Add(this.txtVariation);
            this.scMain.Panel2.Controls.Add(this.txtValue);
            this.scMain.Panel2.Controls.Add(this.txtDiscount);
            this.scMain.Panel2.Controls.Add(this.txtUpdatedAt);
            this.scMain.Panel2.Controls.Add(this.txtCreatedAt);
            this.scMain.Panel2.Controls.Add(this.txtID);
            this.scMain.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.scMain.Size = new System.Drawing.Size(436, 348);
            this.scMain.SplitterDistance = 162;
            this.scMain.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblDescription.Location = new System.Drawing.Point(3, 128);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.ReadOnly = true;
            this.lblDescription.Size = new System.Drawing.Size(156, 16);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblQuantity.Location = new System.Drawing.Point(3, 306);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.ReadOnly = true;
            this.lblQuantity.Size = new System.Drawing.Size(156, 16);
            this.lblQuantity.TabIndex = 14;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblCurrency
            // 
            this.lblCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblCurrency.Location = new System.Drawing.Point(3, 284);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.ReadOnly = true;
            this.lblCurrency.Size = new System.Drawing.Size(156, 16);
            this.lblCurrency.TabIndex = 13;
            this.lblCurrency.Text = "Currency";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblPrice.Location = new System.Drawing.Point(3, 150);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.ReadOnly = true;
            this.lblPrice.Size = new System.Drawing.Size(156, 16);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Price";
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblValue.Location = new System.Drawing.Point(3, 240);
            this.lblValue.Name = "lblValue";
            this.lblValue.ReadOnly = true;
            this.lblValue.Size = new System.Drawing.Size(156, 16);
            this.lblValue.TabIndex = 11;
            this.lblValue.Text = "Value";
            // 
            // lblVariation
            // 
            this.lblVariation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVariation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblVariation.Location = new System.Drawing.Point(3, 262);
            this.lblVariation.Name = "lblVariation";
            this.lblVariation.ReadOnly = true;
            this.lblVariation.Size = new System.Drawing.Size(156, 16);
            this.lblVariation.TabIndex = 12;
            this.lblVariation.Text = "Variation";
            // 
            // lblSKU
            // 
            this.lblSKU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSKU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblSKU.Location = new System.Drawing.Point(3, 106);
            this.lblSKU.Name = "lblSKU";
            this.lblSKU.ReadOnly = true;
            this.lblSKU.Size = new System.Drawing.Size(156, 16);
            this.lblSKU.TabIndex = 5;
            this.lblSKU.Text = "SKU";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblName.Location = new System.Drawing.Point(3, 84);
            this.lblName.Name = "lblName";
            this.lblName.ReadOnly = true;
            this.lblName.Size = new System.Drawing.Size(156, 16);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // lblProduct
            // 
            this.lblProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblProduct.Location = new System.Drawing.Point(3, 218);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.ReadOnly = true;
            this.lblProduct.Size = new System.Drawing.Size(156, 16);
            this.lblProduct.TabIndex = 10;
            this.lblProduct.Text = "Product";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblDiscount.Location = new System.Drawing.Point(3, 196);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.ReadOnly = true;
            this.lblDiscount.Size = new System.Drawing.Size(156, 16);
            this.lblDiscount.TabIndex = 9;
            this.lblDiscount.Text = "Discount (Whole Order)";
            // 
            // lblEditable
            // 
            this.lblEditable.AutoSize = true;
            this.lblEditable.Location = new System.Drawing.Point(3, 178);
            this.lblEditable.Name = "lblEditable";
            this.lblEditable.Size = new System.Drawing.Size(49, 15);
            this.lblEditable.TabIndex = 8;
            this.lblEditable.Text = "Editable";
            // 
            // lblUpdatedAt
            // 
            this.lblUpdatedAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdatedAt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblUpdatedAt.Location = new System.Drawing.Point(3, 62);
            this.lblUpdatedAt.Name = "lblUpdatedAt";
            this.lblUpdatedAt.ReadOnly = true;
            this.lblUpdatedAt.Size = new System.Drawing.Size(156, 16);
            this.lblUpdatedAt.TabIndex = 3;
            this.lblUpdatedAt.Text = "Updated At";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedAt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblCreatedAt.Location = new System.Drawing.Point(3, 40);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.ReadOnly = true;
            this.lblCreatedAt.Size = new System.Drawing.Size(156, 16);
            this.lblCreatedAt.TabIndex = 2;
            this.lblCreatedAt.Text = "Created At";
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblID.Location = new System.Drawing.Point(3, 18);
            this.lblID.Name = "lblID";
            this.lblID.ReadOnly = true;
            this.lblID.Size = new System.Drawing.Size(156, 16);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID";
            // 
            // lblReadOnly
            // 
            this.lblReadOnly.AutoSize = true;
            this.lblReadOnly.Location = new System.Drawing.Point(3, 0);
            this.lblReadOnly.Name = "lblReadOnly";
            this.lblReadOnly.Size = new System.Drawing.Size(63, 15);
            this.lblReadOnly.TabIndex = 0;
            this.lblReadOnly.Text = "Read-Only";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(3, 147);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(264, 23);
            this.txtPrice.TabIndex = 21;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(3, 125);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(264, 23);
            this.txtDescription.TabIndex = 20;
            // 
            // txtSKU
            // 
            this.txtSKU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSKU.Location = new System.Drawing.Point(3, 103);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.ReadOnly = true;
            this.txtSKU.Size = new System.Drawing.Size(264, 23);
            this.txtSKU.TabIndex = 19;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(3, 81);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(264, 23);
            this.txtName.TabIndex = 18;
            // 
            // cbxProduct
            // 
            this.cbxProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProduct.FormattingEnabled = true;
            this.cbxProduct.Location = new System.Drawing.Point(3, 215);
            this.cbxProduct.Name = "cbxProduct";
            this.cbxProduct.Size = new System.Drawing.Size(264, 23);
            this.cbxProduct.TabIndex = 23;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrency.Location = new System.Drawing.Point(3, 281);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(264, 23);
            this.txtCurrency.TabIndex = 26;
            // 
            // txtVariation
            // 
            this.txtVariation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVariation.Location = new System.Drawing.Point(3, 259);
            this.txtVariation.Name = "txtVariation";
            this.txtVariation.Size = new System.Drawing.Size(264, 23);
            this.txtVariation.TabIndex = 25;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(3, 237);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(264, 23);
            this.txtValue.TabIndex = 24;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscount.Location = new System.Drawing.Point(3, 193);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(264, 23);
            this.txtDiscount.TabIndex = 22;
            // 
            // txtUpdatedAt
            // 
            this.txtUpdatedAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdatedAt.Location = new System.Drawing.Point(3, 59);
            this.txtUpdatedAt.Name = "txtUpdatedAt";
            this.txtUpdatedAt.ReadOnly = true;
            this.txtUpdatedAt.Size = new System.Drawing.Size(264, 23);
            this.txtUpdatedAt.TabIndex = 17;
            // 
            // txtCreatedAt
            // 
            this.txtCreatedAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreatedAt.Location = new System.Drawing.Point(3, 37);
            this.txtCreatedAt.Name = "txtCreatedAt";
            this.txtCreatedAt.ReadOnly = true;
            this.txtCreatedAt.Size = new System.Drawing.Size(264, 23);
            this.txtCreatedAt.TabIndex = 16;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Location = new System.Drawing.Point(3, 15);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(264, 23);
            this.txtID.TabIndex = 15;
            // 
            // numQuantity
            // 
            this.numQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numQuantity.Location = new System.Drawing.Point(3, 304);
            this.numQuantity.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(264, 23);
            this.numQuantity.TabIndex = 27;
            // 
            // LineItemPropertyGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Name = "LineItemPropertyGrid";
            this.Size = new System.Drawing.Size(436, 348);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Label lblReadOnly;
        private System.Windows.Forms.TextBox lblID;
        private System.Windows.Forms.TextBox lblCreatedAt;
        private System.Windows.Forms.TextBox lblUpdatedAt;
        private System.Windows.Forms.Label lblEditable;
        private System.Windows.Forms.TextBox lblDiscount;
        private System.Windows.Forms.TextBox lblProduct;
        private System.Windows.Forms.TextBox lblName;
        private System.Windows.Forms.TextBox lblSKU;
        private System.Windows.Forms.TextBox lblVariation;
        private System.Windows.Forms.TextBox lblValue;
        private System.Windows.Forms.TextBox lblPrice;
        private System.Windows.Forms.TextBox lblCurrency;
        private System.Windows.Forms.TextBox lblQuantity;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.TextBox txtVariation;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtUpdatedAt;
        private System.Windows.Forms.TextBox txtCreatedAt;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cbxProduct;
        private System.Windows.Forms.TextBox lblDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numQuantity;
    }
}
