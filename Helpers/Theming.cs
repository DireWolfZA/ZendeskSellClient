using System.Linq;
using System.Windows.Forms;

namespace Helpers {
    public static class Theming {
        private static bool toolStripManagerRendererSet = false;

        public static void ApplyTheme(Form form) {
            var theme = WalkmanLib.Theme.Dark;
            WalkmanLib.ApplyTheme(theme, form, true);

            if (!toolStripManagerRendererSet) {
                ToolStripManager.Renderer = new WalkmanLib.CustomPaint.ToolStripSystemRendererWithDisabled(theme.ToolStripItemDisabledText);
                toolStripManagerRendererSet = true;
            }
        }

        public static void ApplyTheme(System.Collections.IEnumerable controls) {
            var theme = WalkmanLib.Theme.Dark;
            WalkmanLib.ApplyTheme(theme, controls, true);

            if (!toolStripManagerRendererSet) {
                ToolStripManager.Renderer = new WalkmanLib.CustomPaint.ToolStripSystemRendererWithDisabled(theme.ToolStripItemDisabledText);
                toolStripManagerRendererSet = true;
            }
        }
    }
}