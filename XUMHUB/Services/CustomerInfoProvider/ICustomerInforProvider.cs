using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.Services.CustomerInfoProvider
{
    public interface ICustomerInforProvider
    {
        public Task<IEnumerable<CustomerInfoModel>> GetCustomerInfo();
        public Task<CustomerInfoModel> GetByOrderNumber(string orderID);
    }
}
