using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Services.HistoryProvider;

namespace XUMHUB.Model
{
    public class DashboardModel
    {
        private readonly IHistoryProvider historyProvider = new DatabaseHistoryProvider();

        public DashboardModel() { }

        public async Task<int> LaptopBuiltToday()
        {
            return await historyProvider.GetLaptopAmountToday();
        }
    }
}
