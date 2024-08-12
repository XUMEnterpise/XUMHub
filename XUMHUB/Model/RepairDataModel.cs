using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    class RepairDataModel
    {
        public RepairDataModel(string serviceTag, AgentModel agentLogged, DateTime dateLogged, string repairStatus, DateTime? repairedDate, AgentModel agentRepaired, List<FaultModel> faults)
        {
            ServiceTag = serviceTag;
            AgentLogged = agentLogged;
            DateLogged = dateLogged;
            RepairStatus = repairStatus;
            RepairedDate = repairedDate;
            AgentRepaired = agentRepaired;
            Faults = faults;
        }

        public string ServiceTag { get; private set; }
        public AgentModel AgentLogged { get; private set; }
        public DateTime DateLogged { get; private set; }
        public string RepairStatus { get; private set; }
        public DateTime? RepairedDate { get; private set; }
        public AgentModel AgentRepaired { get; private set; }
        public List<FaultModel> Faults { get; private set; }

    }
}
