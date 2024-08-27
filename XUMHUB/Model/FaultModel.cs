using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    public class FaultModel
    {
        public FaultModel(int? faultID,int repairId, string faultName, bool? isRepaired)
        {
            FaultId = faultID;
            RepairId = repairId;
            FaultName = faultName;
            IsRepaired = isRepaired;
        }
        public int? FaultId { get; private set; }
        public int RepairId { get; private set; }
        public string FaultName { get; private set; }
        public bool? IsRepaired { get; set; }

    }
}
