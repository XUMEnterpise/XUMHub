using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Classes;
using XUMHUB.DBContext;
using XUMHUB.DTOS;

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

        private static ReturnsInfoModel ToReturnInfo(ReturnsInfo r)
        {
            return new ReturnsInfoModel(r.ReturnId,r.ReturnDate,r.Status,r.ReasonForReturn,r.AdditionalReturnInfo,r.Diagnosis,r.AdditionalRepairInfo,r.OrderId);
        }
    }
}
