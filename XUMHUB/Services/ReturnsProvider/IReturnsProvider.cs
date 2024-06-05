using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.Services
{
    public interface IReturnsProvider
    {
        public Task<IEnumerable<ReturnsInfoModel>> GetReturnsInfo();
        public Task<IEnumerable<ReturnsInfoModel>> GetReturnInfoByOrderID(string orderID);
    }
}
