using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controls {
    interface IZendeskPropertyGrid<T> where T : Models.Base {
        public abstract void SetData(T data);
        public abstract T GetData();
    }
}
