﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;
using XUMHUB.Model;
using XUMHUB.Services.AgentService;

namespace XUMHUB.Services.RepairDataService
{
    class DatabaseToRepairDataModel : IDatabaseToRepairDataModel
    {
        
        public async Task<IEnumerable<RepairDataModel>> GetAllRepairs()
        {
            IDatabaseToAgent databaseToAgent = new DatabaseToAgent();
            var context = new DBContext();

            var query = from o in context.RepairData
                        join c in context.Faults on o.RepairId equals c.RepairId into faultsGroup
                        select new
                        {
                            o.ServiceTag,
                            o.AgentLogged,
                            o.LoggedDate,
                            o.RepairStatus,
                            o.RepairedDate,
                            o.AgentRepaired,
                            Faults = faultsGroup.ToList()
                        };

            var results = query.ToList();

            var repairsData = results.Select(x => new RepairDataModel(
                 x.ServiceTag,
                 databaseToAgent.GetAgent(x.AgentLogged),
                 x.LoggedDate,
                 x.RepairStatus,
                 x.RepairedDate,
                 databaseToAgent.GetAgent(x.AgentRepaired.ToString()),
                 x.Faults.Select(f => new FaultModel(f.Fault1, f.IsRepaired)).ToList()
            )).ToList();
            return repairsData;
        }

        
    }
}
