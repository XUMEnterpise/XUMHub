using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    public class LaptopInfoModel
    {
        public LaptopInfoModel(string Sku,string model, string cpu, string ram, string storage, string display, string os)
        {
            Model = model;
            Cpu = cpu;
            Ram = ram;
            Storage = storage;
            Display = display;
            this.Sku = Sku;
            Os = os;
        }
        public string Sku { get; private set; }
        public string Model { get; private set; }
        public string Cpu { get; private set; }
        public string Ram { get; private set; }
        public string Storage { get; private set; }
        public string Display { get; private set; }
        public string Os { get; private set; }

    }
}
