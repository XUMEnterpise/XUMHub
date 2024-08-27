using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.Services.AgentService
{
    public class DatabaseToAgent : IDatabaseToAgent
    {
        public AgentModel GetAgent(string agentId)
        {
            using(var db = new DBContext())
            {
                var agent = db.StaffTables.FirstOrDefault(a => a.StaffNumber.ToString() == agentId);
                if (agent == null)
                {
                    return null;
                }
                return new AgentModel(agent.StaffNumber, agent.Name);
            }
        }

        public AgentModel GetAgentByName(string agentName)
        {
            using (var db = new DBContext())
            {
                var agent = db.StaffTables.FirstOrDefault(a => a.Name.ToString() == agentName);
                if (agent == null)
                {
                    return null;
                }
                return new AgentModel(agent.StaffNumber, agent.Name);
            }
        }
    }
}
