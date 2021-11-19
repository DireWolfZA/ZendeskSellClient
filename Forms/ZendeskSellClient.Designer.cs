namespace Forms {
    partial class ZendeskSellClient {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZendeskSellClient));
            this.lstItems = new System.Windows.Forms.ListView();
            this.colHeadID = new System.Windows.Forms.ColumnHeader();
            this.colHeadName = new System.Windows.Forms.ColumnHeader();
            this.colHeadOwner = new System.Windows.Forms.ColumnHeader();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnGetOne = new System.Windows.Forms.Button();
            this.numOneID = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.numDealID = new System.Windows.Forms.NumericUpDown();
            this.lblDealID = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOneID)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDealID)).BeginInit();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.AllowColumnReorder = true;
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadID,
            this.colHeadName,
            this.colHeadOwner});
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(3, 3);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(294, 628);
            this.lstItems.TabIndex = 0;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // colHeadID
            // 
            this.colHeadID.Text = "ID";
            // 
            // colHeadName
            // 
            this.colHeadName.Text = "Name";
            // 
            // colHeadOwner
            // 
            this.colHeadOwner.Text = "Owner";
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(6, 55);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.lstItems);
            this.scMain.Size = new System.Drawing.Size(863, 634);
            this.scMain.SplitterDistance = 300;
            this.scMain.TabIndex = 8;
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.Enabled = false;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "Leads",
            "Contacts",
            "Deals",
            "Line Items"});
            this.cbxType.Location = new System.Drawing.Point(57, 9);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(175, 23);
            this.cbxType.TabIndex = 1;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(6, 26);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(75, 23);
            this.btnGetAll.TabIndex = 2;
            this.btnGetAll.Text = "Get All";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnGetOne
            // 
            this.btnGetOne.Location = new System.Drawing.Point(198, 26);
            this.btnGetOne.Name = "btnGetOne";
            this.btnGetOne.Size = new System.Drawing.Size(75, 23);
            this.btnGetOne.TabIndex = 4;
            this.btnGetOne.Text = "Get One";
            this.btnGetOne.UseVisualStyleBackColor = true;
            this.btnGetOne.Click += new System.EventHandler(this.btnGetOne_Click);
            // 
            // numOneID
            // 
            this.numOneID.Location = new System.Drawing.Point(87, 28);
            this.numOneID.Maximum = int.MaxValue;
            this.numOneID.Name = "numOneID";
            this.numOneID.Size = new System.Drawing.Size(105, 23);
            this.numOneID.TabIndex = 3;
            this.numOneID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numOneID.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(279, 26);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create...";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(360, 26);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grpMain
            // 
            this.grpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMain.Controls.Add(this.btnDelete);
            this.grpMain.Controls.Add(this.numDealID);
            this.grpMain.Controls.Add(this.lblDealID);
            this.grpMain.Controls.Add(this.btnUpdate);
            this.grpMain.Controls.Add(this.btnGetAll);
            this.grpMain.Controls.Add(this.scMain);
            this.grpMain.Controls.Add(this.numOneID);
            this.grpMain.Controls.Add(this.btnCreate);
            this.grpMain.Controls.Add(this.btnGetOne);
            this.grpMain.Enabled = false;
            this.grpMain.Location = new System.Drawing.Point(12, 12);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(875, 695);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Type:";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(441, 26);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // numDealID
            // 
            this.numDealID.Location = new System.Drawing.Point(279, -2);
            this.numDealID.Maximum = int.MaxValue;
            this.numDealID.Name = "numDealID";
            this.numDealID.Size = new System.Drawing.Size(120, 23);
            this.numDealID.TabIndex = 1;
            this.numDealID.Visible = false;
            // 
            // lblDealID
            // 
            this.lblDealID.AutoSize = true;
            this.lblDealID.Location = new System.Drawing.Point(226, 0);
            this.lblDealID.Name = "lblDealID";
            this.lblDealID.Size = new System.Drawing.Size(47, 15);
            this.lblDealID.TabIndex = 0;
            this.lblDealID.Text = "Deal ID:";
            this.lblDealID.Visible = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(806, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // ZendeskSellClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 719);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.grpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ZendeskSellClient";
            this.Text = "ZendeskSellClient";
            this.Shown += new System.EventHandler(this.ZendeskSellClient_Shown);
            this.scMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numOneID)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDealID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnGetOne;
        private System.Windows.Forms.NumericUpDown numOneID;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Label lblDealID;
        private System.Windows.Forms.NumericUpDown numDealID;
        private System.Windows.Forms.ColumnHeader colHeadID;
        private System.Windows.Forms.ColumnHeader colHeadName;
        private System.Windows.Forms.ColumnHeader colHeadOwner;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnDelete;
    }
}
