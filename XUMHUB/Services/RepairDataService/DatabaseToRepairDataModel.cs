using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task<int> CreateRepairEntry(RepairDataModel repairDataModel)
        {
            using(var dbContext=new DBContext())
            {
                RepairDatum repairData = new RepairDatum
                {
                    ServiceTag = repairDataModel.ServiceTag,
                    AgentLogged = repairDataModel.AgentLogged.AgentId.ToString(),
                    LoggedDate = repairDataModel.DateLogged,
                    RepairStatus = repairDataModel.RepairStatus,
                    RepairedDate = repairDataModel.RepairedDate,
                    AgentRepaired = repairDataModel.AgentRepaired==null? null : repairDataModel.AgentRepaired.AgentId
                };
                dbContext.RepairData.Add(repairData);
                dbContext.SaveChanges();
                return repairData.RepairId;
            }
        }

        public async Task<IEnumerable<RepairDataModel>> GetAllRepairs()
        {
            IDatabaseToAgent databaseToAgent = new DatabaseToAgent();
            var context = new DBContext();

            var query = await ( from o in context.RepairData
                        join c in context.Faults on o.RepairId equals c.RepairId into faultsGroup
                        select new
                        {
                            o.RepairId,
                            o.ServiceTag,
                            o.AgentLogged,
                            o.LoggedDate,
                            o.RepairStatus,
                            o.RepairedDate,
                            o.AgentRepaired,
                            Faults = faultsGroup.ToList(),
                            o.DbId
                        }).ToListAsync();

            var results =query;

            var repairsData = results.Select(async x => new RepairDataModel(
                 x.RepairId,
                 x.ServiceTag,
                 await databaseToAgent.GetAgent(x.AgentLogged),
                 x.LoggedDate,
                 x.RepairStatus,
                 x.RepairedDate,
                 await databaseToAgent.GetAgent(x.AgentRepaired.ToString()),
                 x.Faults.Select(f => new FaultModel(f.Id,f.RepairId??0,f.Fault1, f.IsRepaired)).ToList(),
                 x.DbId
            )).ToList();

            var returnRepairsData = await Task.WhenAll(repairsData);
            return returnRepairsData;
        }

        public async Task<RepairDataModel> GetRepair(int repairId)
        {
            using(var context = new DBContext())
            {
                IDatabaseToAgent databaseToAgent = new DatabaseToAgent();
                var query = from o in context.RepairData
                            where o.RepairId == repairId
                            join c in context.Faults on o.RepairId equals c.RepairId into faultsGroup
                            select new
                            {
                                o.RepairId,
                                o.ServiceTag,
                                o.AgentLogged,
                                o.LoggedDate,
                                o.RepairStatus,
                                o.RepairedDate,
                                o.AgentRepaired,
                                Faults = faultsGroup.ToList(),
                                o.DbId
                            };

                var results = query;

                var repairsData = await results
                    .Select(x => new {
                        x.RepairId,
                        x.ServiceTag,
                        AgentLogged = x.AgentLogged,
                        x.LoggedDate,
                        x.RepairStatus,
                        x.RepairedDate,
                        AgentRepaired = x.AgentRepaired.ToString(),
                        Faults = x.Faults.Select(f => new FaultModel(f.Id, f.RepairId ?? 0, f.Fault1, f.IsRepaired)).ToList(),
                        x.DbId
                    })
                    .ToListAsync();

                // Then, perform the async operations
                var repairDataModels = await Task.WhenAll(repairsData.Select(async x => new RepairDataModel(
                    x.RepairId,
                    x.ServiceTag,
                    await databaseToAgent.GetAgent(x.AgentLogged),
                    x.LoggedDate,
                    x.RepairStatus,
                    x.RepairedDate,
                    await databaseToAgent.GetAgent(x.AgentRepaired),
                    x.Faults,
                    x.DbId
                )));

                // Select the first result if that's what you intend to do
                var firstRepairDataModel = repairDataModels.FirstOrDefault();
                return firstRepairDataModel;
            }
        }
    }
}
