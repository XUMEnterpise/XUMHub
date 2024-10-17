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

        public async Task<int> GetLaptopAmount(DateTime date)
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly dateC= DateOnly.FromDateTime(date);

                return await dbContext.Histories.Where(r => r.Channel.Contains("Laptop") && r.Date.Equals(dateC)).CountAsync();
            }
        }
        public async Task<int> GetTestedLaptopAmount(DateTime date)
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly dateC = DateOnly.FromDateTime(date);
                int count = await (from h in dbContext.Histories
                                   join r in dbContext.RepairData on h.Id equals r.DbId
                                   where h.Channel.Contains("Laptop")
                                      && EF.Functions.DateDiffDay(r.RepairedDate, date) == 0
                                   select h)
                      .CountAsync();

                return count;
            }
        }
        public async Task<int> GetDesktopBuilpAmount(DateTime date)
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly dateC = DateOnly.FromDateTime(date);

                return await dbContext.Histories.Where(r => r.Channel.Equals("Prebuilt") && r.Date.Equals(dateC)).CountAsync();
            }
        }

        public async Task<int> GetDesktopOrders(DateTime date)
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly dateC = DateOnly.FromDateTime(date);

                return await dbContext.Histories.Where(r => !r.Channel.Equals("Prebuilt") && !r.Channel.Contains("Laptop") && r.Date.Equals(dateC) && r.Sku.StartsWith("C")).CountAsync();
            }
        }
        public async Task<int> GetLaptopOrders(DateTime date)
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly dateC = DateOnly.FromDateTime(date);

                return await dbContext.Histories.Where(r => !r.Channel.Equals("Prebuilt") && !r.Channel.Contains("Laptop") && r.Date.Equals(dateC) && r.Sku.StartsWith("L") && !r.Sku.StartsWith("LX")).CountAsync();
            }
        }

        public async Task<int> GetTestedDesktops(DateTime date)
        {
            using (DBContext dbContext = new DBContext())
            {
                DateOnly dateC = DateOnly.FromDateTime(date);
                int count = await (from h in dbContext.Histories
                                   join r in dbContext.RepairData on h.Id equals r.DbId
                                   where h.Channel.Contains("Prebuilt")
                                      && EF.Functions.DateDiffDay(r.RepairedDate, date)==0
                                   select h)
                      .CountAsync();

                return count;
            }

        }
    }
}
