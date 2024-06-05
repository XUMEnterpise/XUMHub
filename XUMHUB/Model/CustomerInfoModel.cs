using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    public class CustomerInfoModel
    {
        public int OrderID;
        public string Name;
        public string ChannelRefference;

        public CustomerInfoModel(int orderID, string name, string channelRefference)
        {
            OrderID = orderID;
            Name = name;
            ChannelRefference = channelRefference;
        }
    }
}
