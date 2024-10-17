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
        public Task<int> GetDesktopBuilpAmount(DateTime date);
        public Task<int> GetLaptopAmount(DateTime date);
        public Task<int> GetDesktopOrders(DateTime date);
        public Task<int> GetLaptopOrders(DateTime date);
        public Task<int> GetTestedLaptopAmount(DateTime date);
        public Task<int> GetTestedDesktops(DateTime date);
    }
}
