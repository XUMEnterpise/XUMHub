using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DBContext;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.Services.CustomerInfoProvider
{
    public class DabatabaseCustomerInfoProvider : ICustomerInforProvider
    {
        public async Task<CustomerInfoModel> GetByOrderNumber(string orderID)
        {
            using (XumdbContext dBContext = new XumdbContext())
            {
                IEnumerable<CustomerInfo> customerInfoDTOS = await dBContext.CustomerInfos.Where(r => r.OrderId==orderID).ToListAsync();
                return customerInfoDTOS.Select(r => ToCustomerInfo(r)).LastOrDefault();
            }
        }

        public async Task<IEnumerable<CustomerInfoModel>> GetCustomerInfo()
        {
            using (XumdbContext dBContext = new XumdbContext())
            {
                IEnumerable<CustomerInfo> customerInfoDTOS = await dBContext.CustomerInfos.ToListAsync();
                return customerInfoDTOS.Select(r => ToCustomerInfo(r));
            }
        }
        private static CustomerInfoModel ToCustomerInfo(CustomerInfo r)
        {
            return new CustomerInfoModel(Int32.Parse(r.OrderId),r.CustomerName,r.ChannelReference);
        }
    }
}
