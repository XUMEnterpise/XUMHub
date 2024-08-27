using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.Services.AgentService
{
    public interface IDatabaseToAgent
    {
        AgentModel GetAgent(string agentId);
        AgentModel GetAgentByName(string agentName );
    }
}
