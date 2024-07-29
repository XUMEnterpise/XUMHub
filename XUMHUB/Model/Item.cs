using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    class Item
    {
        public Item(string serviceCode, string sku)
        {
            this.serviceCode = serviceCode;
            this.sku = sku;
        }

        public string serviceCode { get; private set; }
        public string sku { get; private set; }
    }
}
