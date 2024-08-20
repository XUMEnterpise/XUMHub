using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    public class FaultModel
    {
        public FaultModel(string faultName, bool? isRepaired)
        {
            FaultName = faultName;
            IsRepaired = isRepaired;
        }

        public string FaultName { get; private set; }
        public bool? IsRepaired { get; private set; }

    }
}
