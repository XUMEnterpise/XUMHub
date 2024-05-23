using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Classes
{
    class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ChannelReference { get; private set; }
        public Customer(int Id, string Name, string ChannelReference)
        {
            this.Id = Id;
            this.Name = Name;
            this.ChannelReference = ChannelReference;
        }
    }
}
