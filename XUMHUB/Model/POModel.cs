using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    public class POModel
    {
        public POModel(string pONumber, string pOTitle, List<POEntryModel> pOEntries)
        {
            PONumber = pONumber;
            POTitle = pOTitle;
            this.pOEntries = pOEntries;
        }

        public string PONumber { get; private set; }
        public string POTitle { get; private set; }
        public List<POEntryModel> pOEntries { get; private set; }
    }
}
