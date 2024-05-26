using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Classes;

namespace XUMHUB.Services
{
    public interface IReturnsProvider
    {
        public Task<IEnumerable<ReturnsInfoModel>> GetReturnsInfo();
    }
}
