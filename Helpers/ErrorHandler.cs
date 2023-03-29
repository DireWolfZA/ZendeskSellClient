using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Helpers {
    class ErrorHandler {
        public static void Handle(Exception ex, string errorMessage = "There was an error! Error message: ") {
            var settings = Program.Services.GetRequiredService<Forms.Settings>();
            var mainWindow = Program.Services.GetRequiredService<Forms.ZendeskSellClient>();

            if (ex is AggregateException aggregate) {
                var zdErrors = aggregate.InnerExceptions.OfType<ZendeskError>();

                errorMessage += $"{aggregate.InnerException.Message}{Environment.NewLine}{Environment.NewLine}";

                foreach (var zdError in zdErrors) {
                    errorMessage += $"{zdError.ErrorData.Message}: {zdError.ErrorData.Field} - {zdError.ErrorData.Details}{Environment.NewLine}";
                }

                WalkmanLib.CustomMsgBox(errorMessage, settings.GetTheme(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning, ownerForm: mainWindow);
            } else {
                WalkmanLib.ErrorDialog(ex, settings.GetTheme(), errorMessage, ownerForm: mainWindow);
            }
        }
    }
}
