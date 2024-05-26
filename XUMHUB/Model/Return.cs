using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Classes;
using XUMHUB.Services;

namespace XUMHUB.Model
{
    public class Return
    {
        private readonly IReturnsProvider returnsProvider;

        public Return(IReturnsProvider returnsProvider)
        {
            this.returnsProvider = returnsProvider;
        }

        public async Task<IEnumerable<ReturnsInfoModel>> GetAllReturnsInfo()
        {
            return await returnsProvider.GetReturnsInfo();
        }
    }
}
