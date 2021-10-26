using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZendeskSell.Models;

namespace Helpers {
    class ZendeskError : Exception {
        public ZendeskResponseErrorData ErrorData { get; }
        public ZendeskResponseMetadata Metadata { get; }

        public ZendeskError(ZendeskResponseError error) : base(error.Error?.Message) {
            ErrorData = error.Error;
            Metadata = error.Meta;
        }
        public ZendeskError(ZendeskResponseErrorData error) : base(error.Message) {
            ErrorData = error;
        }
        public ZendeskError(ZendeskResponseMetadata error) : base(error.HTTPStatus) {
            Metadata = error;
        }
        public override string ToString() {
            var sb = new StringBuilder();
            var str = base.ToString().Split(Environment.NewLine, 2, StringSplitOptions.None);
            sb.AppendLine(str[0]);

            if (ErrorData != null) {
                var lineData = new List<string>();
                if (!string.IsNullOrWhiteSpace(ErrorData.Resource))
                    lineData.Add($"Resource: {ErrorData.Resource}");
                if (!string.IsNullOrWhiteSpace(ErrorData.Field))
                    lineData.Add($"Field: {ErrorData.Field}");
                if (!string.IsNullOrWhiteSpace(ErrorData.Code))
                    lineData.Add($"Code: {ErrorData.Code}");
                if (!string.IsNullOrWhiteSpace(ErrorData.Message))
                    lineData.Add($"Message: {ErrorData.Message}");
                if (!string.IsNullOrWhiteSpace(ErrorData.Details))
                    lineData.Add($"Details: {ErrorData.Details}");
                sb.AppendLine(string.Join(", ", lineData));
            }
            if (Metadata != null && Metadata.Type == "error") {
                sb.AppendLine($"Link: {Metadata.Links.MoreInfo}");
            }

            if (str.Length > 1)
                sb.Append(str[1]);
            else // remove trailing newline if we don't append base last line of text
                sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public static AggregateException FromErrors(IEnumerable<ZendeskResponseError> errors) =>
            new AggregateException(errors.Select(e => new ZendeskError(e)));
    }
}
