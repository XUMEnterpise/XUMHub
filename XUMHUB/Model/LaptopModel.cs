using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    class LaptopModel : Item
    {
        public LaptopInfoModel laptopInfo { get;private set; }
        public LaptopModel(string serviceCode, string sku, LaptopInfoModel laptopInfo) : base(serviceCode, sku)
        {
            this.laptopInfo = laptopInfo;
        }
    }
}
