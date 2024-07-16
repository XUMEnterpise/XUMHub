using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    public class POEntryModel
    {
        public POEntryModel(string sKU, int qTY)
        {
            SKU = sKU;
            QTY = qTY;
        }

        public string SKU { get; private set; }
        public int QTY { get; private set; }

    }
}
