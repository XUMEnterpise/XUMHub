using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.Services.HistoryProvider
{
    public class DatabaseHistoryProvider : IHistoryProvider
    {
        public async Task<IEnumerable<HistoryModel>> GetAllHistory()
        {
            using (DBContext dbContext = new DBContext())
            {
                IEnumerable<History> returnsInfoDTO = await dbContext.Histories.ToListAsync();
                return returnsInfoDTO.Select(r => ToOrderModel(r));
            }
        }
        public async Task<HistoryModel> GetOrderByOrderID(string orderID)
        {
            using (DBContext dbContext = new DBContext())
            {
                IEnumerable<History> histories = await dbContext.Histories.Where(r => r.Orderid == orderID).ToListAsync();
                return histories.Select(r => ToOrderModel(r)).LastOrDefault();
            }
        }
        private static HistoryModel ToOrderModel(History r)
        {
            return new HistoryModel(r.Id,r.Orderid,r.Sku,Int32.Parse(r.Qty),r.Channel,r.Date,r.IsTested,r.TestedBy,r.TestStatus);
        }

        public async Task<int> GetLaptopAmountToday()
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly date= DateOnly.FromDateTime(DateTime.Today);

                return await dbContext.Histories.Where(r => r.Channel.Equals("Laptop") && r.Date.Equals(date)).CountAsync();
            }
        }
        public async Task<int> GetDesktopBuilpAmountToday()
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly date = DateOnly.FromDateTime(DateTime.Today);

                return await dbContext.Histories.Where(r => r.Channel.Equals("Prebuilt") && r.Date.Equals(date)).CountAsync();
            }
        }

        public async Task<int> GetDesktopOrdersToday()
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly date = DateOnly.FromDateTime(DateTime.Today);

                return await dbContext.Histories.Where(r => !r.Channel.Equals("Prebuilt") && !r.Channel.Equals("Laptop") && r.Date.Equals(date) && r.Sku.StartsWith("C")).CountAsync();
            }
        }
        public async Task<int> GetLaptopOrdersToday()
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly date = DateOnly.FromDateTime(DateTime.Today);

                return await dbContext.Histories.Where(r => !r.Channel.Equals("Prebuilt") && !r.Channel.Equals("Laptop") && r.Date.Equals(date) && r.Sku.StartsWith("L")).CountAsync();
            }
        }

    }
}
