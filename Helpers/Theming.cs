using System.Linq;
using System.Windows.Forms;
using Forms;

namespace Helpers {
    public static class Theming {
        private static bool toolStripManagerRendererSet = false;

        public static void ApplyTheme(Form form) {
            if (form == null)
                return;

            var theme = Settings.I.GetTheme();
            WalkmanLib.ApplyTheme(theme, form, true);

            if (!toolStripManagerRendererSet) {
                ToolStripManager.Renderer = new WalkmanLib.CustomPaint.ToolStripSystemRendererWithDisabled(theme.ToolStripItemDisabledText);
                toolStripManagerRendererSet = true;
            }
        }

        public static void ApplyTheme(System.Collections.IEnumerable controls) {
            if (controls == null)
                return;

            var theme = Settings.I.GetTheme();
            WalkmanLib.ApplyTheme(theme, controls, true);

            if (!toolStripManagerRendererSet) {
                ToolStripManager.Renderer = new WalkmanLib.CustomPaint.ToolStripSystemRendererWithDisabled(theme.ToolStripItemDisabledText);
                toolStripManagerRendererSet = true;
            }
        }

        public static void AddListViewCustomPaint(ListView listView) {
            listView.DrawItem += WalkmanLib.CustomPaint.ListView_DrawDefaultItem;
            listView.DrawSubItem += WalkmanLib.CustomPaint.ListView_DrawDefaultSubItem;
            listView.DrawColumnHeader += WalkmanLib.CustomPaint.ListView_DrawCustomColumnHeader;
        }
    }
}
