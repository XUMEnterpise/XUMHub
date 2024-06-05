using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DBContext;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.Services.HistoryProvider
{
    public class DatabaseHistoryProvider : IHistoryProvider
    {
        public async Task<IEnumerable<HistoryModel>> GetAllHistory()
        {
            using (XumdbContext dbContext = new XumdbContext())
            {
                IEnumerable<History> returnsInfoDTO = await dbContext.Histories.ToListAsync();
                return returnsInfoDTO.Select(r => ToOrderModel(r));
            }
        }
        public async Task<HistoryModel> GetOrderByOrderID(string orderID)
        {
            using (XumdbContext dbContext = new XumdbContext())
            {
                IEnumerable<History> histories = await dbContext.Histories.Where(r => r.OrderId == orderID).ToListAsync();
                return histories.Select(r => ToOrderModel(r)).LastOrDefault();
            }
        }
        private static HistoryModel ToOrderModel(History r)
        {
            return new HistoryModel(r.Id,r.OrderId,r.Sku,r.Qty,r.Channel,r.Date,r.IsTested,r.TestedBy,r.TestStatus);
        }

        public async Task<int> GetLaptopAmountToday()
        {
            using (XumdbContext dbContext = new XumdbContext())
            {
                DateOnly date= DateOnly.FromDateTime(DateTime.Today);

                return await dbContext.Histories.Where(r => r.Sku.StartsWith("L") && r.Date==date).CountAsync();
            }
        }
    }
}
