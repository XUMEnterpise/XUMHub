using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Helpers;
using XUMHUB.Services.HistoryProvider;

namespace XUMHUB.Model
{
    public class DashboardModel
    {
        private readonly IHistoryProvider historyProvider = new DatabaseHistoryProvider();
        private readonly GoogleChatWebhook googleChatWebhook = new GoogleChatWebhook();

        public DashboardModel() { }

        public async Task<int> LaptopBuilt(DateTime date)
        {
            return await historyProvider.GetLaptopAmount(date);
        }
        public async Task<int> DesktopBuilt(DateTime date)
        {
            return await historyProvider.GetDesktopBuilpAmount(date);
        }
        public async Task<int> DesktopOrders(DateTime date)
        {
            return await historyProvider.GetDesktopOrders(date);
        }
        public async Task<int> LaptopOrders(DateTime date)
        {
            return await historyProvider.GetLaptopOrders(date);
        }

        internal async Task<int> LaptopTested(DateTime date)
        {
            return await historyProvider.GetTestedLaptopAmount(date);
        }

        internal async Task<int> DesktopsTested(DateTime date)
        {
            return await historyProvider.GetTestedDesktops(date);
        }
        internal async Task SendChatMessage(string message,string chatHook)
        {
            googleChatWebhook.SendWebhook(message,chatHook);
        }
    }
}
