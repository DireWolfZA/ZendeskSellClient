using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZendeskSell.Models;

namespace Helpers {
    public static class ZendeskGet {
        private static StatusLabelManagerStatusSet SetStatus(StatusLabelManager labelManager, string statusText, StatusLabelManagerStatusSet oldsetStatus) {
            if (labelManager == null)
                return null;
            if (oldsetStatus != null)
                oldsetStatus.Dispose();
            return labelManager.SetStatus(statusText);
        }

        public async static Task<IEnumerable<T>> GetAll<T>(Func<int, int, Task<ZendeskSellCollectionResponse<T>>> getFunc, StatusLabelManager labelManager = null) where T : class {
            string resultName = typeof(T).Name;
            const int pageAmount = 100;

            int pageNumber = 1;
            StatusLabelManagerStatusSet labelSetStatus = SetStatus(labelManager, $"Page {pageNumber}", null);
            var response = await getFunc(pageNumber, pageAmount);

            if (response?.Errors != null)
                throw ZendeskError.FromErrors(response.Errors);

            IEnumerable<T> rtn = response.Items.Select(zds => zds.Data);

            while (response.Meta.Count == pageAmount) {
                pageNumber++;
                labelSetStatus = SetStatus(labelManager, $"Page {pageNumber}", labelSetStatus);
                response = await getFunc(pageNumber, pageAmount);

                if (response?.Errors != null)
                    throw ZendeskError.FromErrors(response.Errors);

                rtn = rtn.Concat(response.Items.Select(zds => zds.Data));
            }

            labelSetStatus?.Dispose();
            return rtn;
        }

        public static T Handle<T>(ZendeskSellObjectResponse<T> response) where T : class {
            if (response?.Errors != null)
                throw ZendeskError.FromErrors(response.Errors);
            if (response == null)
                throw new ApplicationException("No Data returned");

            return response.Data;
        }

        public static void Handle(ZendeskSellDeleteResponse response) {
            if (response?.Errors != null)
                throw ZendeskError.FromErrors(response.Errors);
        }

        public async static Task<ZendeskSell.Orders.OrderResponse> GetOrder(ZendeskSell.Orders.IOrderActions orderActions, long dealID) {
            var orders = await GetAll((pn, pc) => orderActions.GetAsync(pn, pc, dealID));
            if (orders.Count() == 0)
                return Handle(await orderActions.CreateAsync(new ZendeskSell.Orders.OrderRequest() {
                    DealID = dealID,
                    Discount = 0
                }));
            else
                return orders.First();
        }
    }
}
