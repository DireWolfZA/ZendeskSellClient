using System.Windows.Forms;

namespace Helpers {
    public static class Theming {
        private static bool toolStripManagerRendererSet = false;

        public static void ApplyTheme(WalkmanLib.Theme theme, Form form) {
            if (form == null)
                return;

            WalkmanLib.ApplyTheme(theme, form, true);

            if (!toolStripManagerRendererSet) {
                ToolStripManager.Renderer = new WalkmanLib.CustomPaint.ToolStripSystemRendererWithDisabled(theme.ToolStripItemDisabledText);
                toolStripManagerRendererSet = true;
            }
        }

        public static void ApplyTheme(WalkmanLib.Theme theme, System.Collections.IEnumerable controls) {
            if (controls == null)
                return;

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
