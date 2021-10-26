using System.Reflection;
using System.Windows.Forms;

namespace Helpers {
    public static class Extensions {
        public static void DoubleBuffered(this Control control, bool enable) {
            //thanks to https://stackoverflow.com/a/15268338/2999220
            PropertyInfo doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }
    }
}
