using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    public class AgentModel
    {
        public AgentModel(int? agentId, string agentName)
        {
            AgentId = agentId;
            AgentName = agentName;
        }

        public int? AgentId { get; private set; }
        public string AgentName { get; private set; }
    }
}
