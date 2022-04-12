using System;
using System.Linq;
using System.Windows.Forms;

namespace Helpers {
    class ErrorHandler {
        public static void Handle(Exception ex, string errorMessage = "There was an error! Error message: ") {
            if (ex is AggregateException aggregate) {
                var zdErrors = aggregate.InnerExceptions.OfType<ZendeskError>();

                errorMessage += $"{aggregate.InnerException.Message}{Environment.NewLine}{Environment.NewLine}";

                foreach (var zdError in zdErrors) {
                    errorMessage += $"{zdError.ErrorData.Message}: {zdError.ErrorData.Field} - {zdError.ErrorData.Details}{Environment.NewLine}";
                }

                MessageBox.Show(errorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                WalkmanLib.ErrorDialog(ex, errorMessage);
            }
        }
    }
}
