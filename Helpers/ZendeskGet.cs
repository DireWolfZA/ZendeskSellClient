using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZendeskSell.Models;

namespace Helpers {
    public static class ZendeskGet {
        public async static Task<IEnumerable<T>> GetAll<T>(Func<int, int, Task<ZendeskSellCollectionResponse<T>>> getFunc) where T : class {
            string resultName = typeof(T).Name;
            const int pageAmount = 100;

            int pageNumber = 1;
            var response = await getFunc(pageNumber, pageAmount);

            if (response?.Errors != null)
                throw ZendeskError.FromErrors(response.Errors);

            IEnumerable<T> rtn = response.Items.Select(zds => zds.Data);

            while (response.Meta.Count == pageAmount) {
                pageNumber++;
                response = await getFunc(pageNumber, pageAmount);

                if (response?.Errors != null)
                    throw ZendeskError.FromErrors(response.Errors);

                rtn = rtn.Concat(response.Items.Select(zds => zds.Data));
            }

            return rtn;
        }

        public static T Handle<T>(ZendeskSellObjectResponse<T> response) where T : class {
            if (response?.Errors != null)
                throw ZendeskError.FromErrors(response.Errors);

            return response.Data;
        }

        public static void Handle(ZendeskSellDeleteResponse response) {
            if (response?.Errors != null)
                throw ZendeskError.FromErrors(response.Errors);
        }
    }
}
