using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Helpers {
    public class StatusLabelManager {
        private readonly ToolStripStatusLabel label;

        public StatusLabelManager(ToolStripStatusLabel label) {
            this.label = label;
        }

        private List<string> statuses = new List<string>();

        private void setLabelText() => label.Text = string.Join(", ", statuses) + "...";

        public void AddStatus(string text) {
            statuses.Add(text);
            setLabelText();
            label.Image = Properties.Resources.Loading;
        }

        public void RemoveStatus(string text) {
            statuses.Remove(text);
            setLabelText();
            if (statuses.Count == 0) {
                label.Text = "Done.";
                label.Image = null;
            }
        }

        public StatusLabelManagerStatusSet SetStatus(string text) {
            AddStatus(text);
            return new StatusLabelManagerStatusSet(this, text);
        }
    }

    public class StatusLabelManagerStatusSet : IDisposable {
        private bool disposed;
        private readonly StatusLabelManager owner;
        private readonly string statusToDisable;

        public StatusLabelManagerStatusSet(StatusLabelManager owner, string statusToDisable) {
            this.owner = owner;
            this.statusToDisable = statusToDisable;
        }

        public void Dispose() {
            if (!disposed) {
                owner.RemoveStatus(statusToDisable);
                disposed = true;
            }
        }
    }
}
