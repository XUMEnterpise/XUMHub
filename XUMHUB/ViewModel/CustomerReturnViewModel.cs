using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    public class CustomerReturnViewModel : BaseViewModel
    {
        ReturnsInfoViewModel ReturnsInfo { get;  }
        public string OrderNumber => ReturnsInfo.OrderID;
        public string SKU => ReturnsInfo.SKU;
        public CustomerReturnViewModel(ReturnsInfoViewModel returnsInfo)
        {
            ReturnsInfo = returnsInfo;
        }
    }
}
