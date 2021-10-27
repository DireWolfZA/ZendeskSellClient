using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controls {
    interface IZendeskPropertyGrid<T> where T : Models.Base {
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
    }
}
