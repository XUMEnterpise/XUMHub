using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DBContext;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.Services.ReturnsProvider
{
    class DatabaseReturnsInfoProvider : IReturnsProvider
    {


        public async Task<IEnumerable<ReturnsInfoModel>> GetReturnsInfo()
        {
            using(XumdbContext dbContext = new XumdbContext())
            {
                IEnumerable<ReturnsInfo> returnsInfoDTO = await dbContext.ReturnsInfos.ToListAsync();
                return returnsInfoDTO.Select(r => ToReturnInfo(r));
            }
        }
        public async Task<IEnumerable<ReturnsInfoModel>> GetReturnInfoByOrderID(string orderID)
        {
            using (XumdbContext dbContext = new XumdbContext())
            {
                IEnumerable<ReturnsInfo> returnsInfoDTO = await dbContext.ReturnsInfos.Where(r => r.OrderId == orderID).ToListAsync();
                return returnsInfoDTO.Select(r => ToReturnInfo(r));
            }
        }

        private static ReturnsInfoModel ToReturnInfo(ReturnsInfo r)
        {
            return new ReturnsInfoModel(r.ReturnId,r.ReturnDate,r.Status,r.ReasonForReturn,r.AdditionalReturnInfo,r.Diagnosis,r.AdditionalRepairInfo,r.OrderId);
        }
    }
}
