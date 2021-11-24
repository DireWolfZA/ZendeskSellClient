
namespace Forms {
    partial class Settings {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnShowSettingsFile = new System.Windows.Forms.Button();
            this.lblTheme = new System.Windows.Forms.Label();
            this.cbxTheme = new System.Windows.Forms.ComboBox();
            this.lblAccessToken = new System.Windows.Forms.Label();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.chkAutoGetAll = new System.Windows.Forms.CheckBox();
            this.chkAutoRefreshDeps = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 114);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(93, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Force-Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveSettings);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReload.Location = new System.Drawing.Point(174, 114);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(96, 23);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "Reload Settings";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.LoadSettings);
            // 
            // btnShowSettingsFile
            // 
            this.btnShowSettingsFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowSettingsFile.Location = new System.Drawing.Point(276, 114);
            this.btnShowSettingsFile.Name = "btnShowSettingsFile";
            this.btnShowSettingsFile.Size = new System.Drawing.Size(110, 23);
            this.btnShowSettingsFile.TabIndex = 7;
            this.btnShowSettingsFile.Text = "Show Settings File";
            this.btnShowSettingsFile.UseVisualStyleBackColor = true;
            this.btnShowSettingsFile.Click += new System.EventHandler(this.btnShowSettingsFile_Click);
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(12, 38);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(46, 15);
            this.lblTheme.TabIndex = 2;
            this.lblTheme.Text = "Theme:";
            // 
            // cbxTheme
            // 
            this.cbxTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTheme.FormattingEnabled = true;
            this.cbxTheme.Location = new System.Drawing.Point(95, 35);
            this.cbxTheme.Name = "cbxTheme";
            this.cbxTheme.Size = new System.Drawing.Size(291, 23);
            this.cbxTheme.TabIndex = 3;
            this.cbxTheme.SelectedIndexChanged += new System.EventHandler(this.cbxTheme_SelectedIndexChanged);
            // 
            // lblAccessToken
            // 
            this.lblAccessToken.AutoSize = true;
            this.lblAccessToken.Location = new System.Drawing.Point(12, 9);
            this.lblAccessToken.Name = "lblAccessToken";
            this.lblAccessToken.Size = new System.Drawing.Size(80, 15);
            this.lblAccessToken.TabIndex = 0;
            this.lblAccessToken.Text = "Access Token:";
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccessToken.Location = new System.Drawing.Point(95, 6);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(291, 23);
            this.txtAccessToken.TabIndex = 1;
            this.txtAccessToken.TextChanged += new System.EventHandler(this.txtAccessToken_TextChanged);
            // 
            // chkAutoGetAll
            // 
            this.chkAutoGetAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoGetAll.AutoEllipsis = true;
            this.chkAutoGetAll.Location = new System.Drawing.Point(12, 89);
            this.chkAutoGetAll.Name = "chkAutoGetAll";
            this.chkAutoGetAll.Size = new System.Drawing.Size(374, 19);
            this.chkAutoGetAll.TabIndex = 8;
            this.chkAutoGetAll.Text = "Get all items after changing type";
            this.chkAutoGetAll.UseVisualStyleBackColor = true;
            this.chkAutoGetAll.CheckedChanged += new System.EventHandler(this.chkAutoGetAll_CheckedChanged);
            // 
            // chkAutoRefreshDeps
            // 
            this.chkAutoRefreshDeps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoRefreshDeps.Location = new System.Drawing.Point(12, 64);
            this.chkAutoRefreshDeps.Name = "chkAutoRefreshDeps";
            this.chkAutoRefreshDeps.Size = new System.Drawing.Size(374, 19);
            this.chkAutoRefreshDeps.TabIndex = 9;
            this.chkAutoRefreshDeps.Text = "Refresh all dependencies after changing type";
            this.chkAutoRefreshDeps.UseVisualStyleBackColor = true;
            this.chkAutoRefreshDeps.CheckedChanged += new System.EventHandler(this.chkAutoRefreshDeps_CheckedChanged);
            // 
            // Settings
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(398, 149);
            this.Controls.Add(this.chkAutoRefreshDeps);
            this.Controls.Add(this.chkAutoGetAll);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.lblAccessToken);
            this.Controls.Add(this.cbxTheme);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.btnShowSettingsFile);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.VisibleChanged += new System.EventHandler(this.this_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnReload;
        internal System.Windows.Forms.Button btnShowSettingsFile;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.ComboBox cbxTheme;
        private System.Windows.Forms.Label lblAccessToken;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.CheckBox chkAutoGetAll;
        private System.Windows.Forms.CheckBox chkAutoRefreshDeps;
    }
}