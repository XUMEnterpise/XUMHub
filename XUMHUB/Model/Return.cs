using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Services;
using XUMHUB.Services.CustomerInfoProvider;
using XUMHUB.Services.HistoryProvider;

namespace XUMHUB.Model
{
    public class Return
    {
        private readonly IReturnsProvider returnsProvider;
        private readonly IHistoryProvider historyProvider;
        private readonly ICustomerInforProvider customerInforProvider;

        public Return(IReturnsProvider returnsProvider, IHistoryProvider historyProvider, ICustomerInforProvider customerInforProvider)
        {
            this.returnsProvider = returnsProvider;
            this.historyProvider = historyProvider;
            this.customerInforProvider = customerInforProvider;
        }

        public async Task<IEnumerable<ReturnsInfoModel>> GetAllReturnsInfo()
        {
            return await returnsProvider.GetReturnsInfo();
        }
        public async Task<IEnumerable<ReturnsInfoModel>> GetReturnInfoByOrderID(string orderID)
        {
            return await returnsProvider.GetReturnInfoByOrderID(orderID);
        }
        public async Task<IEnumerable<HistoryModel>> GetAllHistoryInfo()
        {
            return await historyProvider.GetAllHistory();
        }
        public async Task<CustomerInfoModel> GetCustomerByOrderNumber(string orderID)
        {
            return await customerInforProvider.GetByOrderNumber(orderID);
        }
        public async Task<HistoryModel> GetOrderByOrderID(string orderID)
        {
            return await historyProvider.GetOrderByOrderID(orderID);
        }
    }
}
