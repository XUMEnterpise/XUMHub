using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    public class RepairDataModel
    {
        public RepairDataModel(int repairId,string serviceTag, AgentModel agentLogged, DateTime? dateLogged, string repairStatus, DateTime? repairedDate, AgentModel agentRepaired, List<FaultModel> faults, int dbID)
        {
            RepairId = repairId;
            ServiceTag = serviceTag;
            AgentLogged = agentLogged;
            DateLogged = dateLogged;
            RepairStatus = repairStatus;
            RepairedDate = repairedDate;
            AgentRepaired = agentRepaired;
            Faults = faults;
            DbID = dbID;
        }
        public int RepairId { get; private set; }
        public string ServiceTag { get; private set; }
        public AgentModel AgentLogged { get; private set; }
        public DateTime? DateLogged { get; private set; }
        public string RepairStatus { get; private set; }
        public DateTime? RepairedDate { get; private set; }
        public AgentModel AgentRepaired { get; private set; }
        public List<FaultModel> Faults { get; private set; }
        public int DbID { get; private set; }

    }
}
