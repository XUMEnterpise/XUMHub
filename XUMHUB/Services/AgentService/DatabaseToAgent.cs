using Microsoft.EntityFrameworkCore;
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
                    return new AgentModel(9999,"N/A");
                }
                return new AgentModel(agent.StaffNumber, agent.Name);
            }
        }

    }
}
