using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.Services.HistoryProvider
{
    public interface IHistoryProvider
    {
        public Task<IEnumerable<HistoryModel>> GetAllHistory();
        public Task<HistoryModel> GetOrderByOrderID(string orderID);
        public Task<int> GetDesktopBuilpAmountToday();
        public Task<int> GetLaptopAmountToday();
        public Task<int> GetDesktopOrdersToday();
        public Task<int> GetLaptopOrdersToday();
        public Task<int> GetTestedLaptopAmountToday();
        public Task<int> GetTestedDesktopsToday();
    }
}
