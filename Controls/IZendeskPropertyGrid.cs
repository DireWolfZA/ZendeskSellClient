using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controls {
    public abstract class IZendeskPropertyGrid : UserControl {
        public abstract void ApplyTheme(WalkmanLib.Theme theme);
    }
    public abstract class IZendeskPropertyGrid<T> : IZendeskPropertyGrid where T : Models.Base {
        public abstract void SetData(T data);
        public abstract T GetData();
    }

    static class ZendeskPropertyGridMethods {
        internal static void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo {
                FileName = ((LinkLabel)sender).Text,
                UseShellExecute = true // required on .Net Core
            });
        }

        internal static void SplitContainer_Panel1_Scroll(SplitContainer sc) {
            bool scrolling = (bool)sc.Tag;
            if (scrolling)
                return;

            sc.Tag = true;
            sc.Panel2.VerticalScroll.Value = sc.Panel1.VerticalScroll.Value;
            sc.Tag = false;
        }
        internal static void SplitContainer_Panel2_Scroll(SplitContainer sc) {
            bool scrolling = (bool)sc.Tag;
            if (scrolling)
                return;

            sc.Tag = true;
            sc.Panel1.VerticalScroll.Value = sc.Panel2.VerticalScroll.Value;
            sc.Tag = false;
        }

        internal static void AddressEditButton_Click(Forms.Settings settings, TextBox txtAddress) {
            var address = (Models.Address)txtAddress.Tag;

            var addressEditor = new Forms.AddressEditor(settings, address ?? new Models.Address());
            if (addressEditor.ShowDialog() == DialogResult.OK) {
                address = new Models.Address(addressEditor.Address);

                txtAddress.Tag = address;
                txtAddress.Text = address.ToTextOneLine();
            }
        }

        internal static void TagEditButton_Click(Forms.Settings settings, TextBox txtTags) {
            var tags = (IEnumerable<string>)txtTags.Tag;

            var tagEditor = new Forms.TagEditor(settings, tags ?? new string[0]);
            if (tagEditor.ShowDialog() == DialogResult.OK) {
                tags = tagEditor.Tags;

                txtTags.Tag = tags;
                txtTags.Text = string.Join(',', tags); ;
            }
        }

        #region Custom Fields
        internal static void CreateCustomFields(IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields, Dictionary<string, Control> customFieldControls,
                                                Panel customFieldLabels, Panel customFieldValues) {
            int yPos = 0;
            foreach (var field in customFields) {
                var fieldLabel = new TextBox() {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    BorderStyle = BorderStyle.None,
                    Location = new System.Drawing.Point(0, yPos + 3),
                    ReadOnly = true,
                    Size = new System.Drawing.Size(customFieldLabels.Width, 16),
                    Text = field.Name
                };
                customFieldLabels.Controls.Add(fieldLabel);

                Control fieldInput;
                Type type = ZendeskSell.CustomFields.ZendeskTypeToDotNetType.GetType(field.Type);

                if (type == typeof(IEnumerable<string>)) {
                    fieldInput = new ListBox() {
                        SelectionMode = SelectionMode.MultiSimple
                    };
                    fieldInput.Tag = field.Choices;
                    ((ListBox)fieldInput).Items.AddRange(field.Choices.Select(c => c.Name).ToArray());
                } else if (type == typeof(string) && field.Type == "list") {
                    fieldInput = new ComboBox() {
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    fieldInput.Tag = field.Choices;
                    ((ComboBox)fieldInput).Items.Add("");
                    ((ComboBox)fieldInput).Items.AddRange(field.Choices.Select(c => c.Name).ToArray());
                    ((ComboBox)fieldInput).SelectedIndex = 0;
                } else if (type == typeof(string) || type == typeof(Models.Address)) {
                    fieldInput = new TextBox();
                } else if (type == typeof(bool)) {
                    fieldInput = new CheckBox();
                } else {
                    throw new ApplicationException("Unexpected type: " + type.FullName);
                }

                fieldInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                fieldInput.Location = new System.Drawing.Point(0, yPos);
                fieldInput.Size = new System.Drawing.Size(customFieldValues.Width, 23);
                customFieldValues.Controls.Add(fieldInput);
                customFieldControls.Add(field.Name, fieldInput);

                yPos += 22;
            }
        }

        internal static void SetCustomFieldValues(IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields, Dictionary<string, Control> customFieldControls,
                                                   Dictionary<string, object> customFieldValues) {
            foreach (var kv in customFieldControls) {
                if (customFieldValues.ContainsKey(kv.Key)) {
                    var field = customFieldValues[kv.Key];
                    string zdType = customFields.First(f => f.Name == kv.Key).Type;
                    Type type = ZendeskSell.CustomFields.ZendeskTypeToDotNetType.GetType(zdType);

                    if (type == typeof(bool))
                        ((CheckBox)customFieldControls[kv.Key]).Checked = (bool)field;
                    else if (type == typeof(Models.Address))
                        customFieldControls[kv.Key].Text = ((Models.Address)field).ToTextOneLine();
                    else
                        customFieldControls[kv.Key].Text = field.ToString();
                } else {
                    if (kv.Value is CheckBox chk)
                        chk.Checked = false;
                    else
                        kv.Value.Text = "";
                }
            }
        }

        internal static Dictionary<string, object> GetCustomFieldValues(IEnumerable<ZendeskSell.CustomFields.CustomFieldResponse> customFields,
                                                                        Dictionary<string, Control> customFieldControls) {
            var rtn = new Dictionary<string, object>();

            foreach (var field in customFields) {
                Control control = customFieldControls[field.Name];
                Type type = ZendeskSell.CustomFields.ZendeskTypeToDotNetType.GetType(field.Type);

                if (type == typeof(bool))
                    rtn.Add(field.Name, ((CheckBox)customFieldControls[field.Name]).Checked);
                else if (type == typeof(Models.Address))
                    rtn.Add(field.Name, new ZendeskSell.Models.Address((Models.Address)control.Tag));
                else
                    rtn.Add(field.Name, control.Text);
            }

            return rtn;
        }
        #endregion
    }
}
