using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.Services.RepairDataService
{
    class DatabaseToRepairDataModel : IDatabaseToRepairDataModel
    {
        public Task<IEnumerable<RepairDataModel>> GetAllRepairs()
        {
            using(var context = new DBContext())
            {
                var repairsData = from o in context.RepairData 
                                  join c in context.Faults on o.RepairId equals c.RepairId into faultsGroup
                                  select new {
                                      ServiveTag= o.ServiceTag,
                                      AgentLogged = o.AgentLogged,
                                      DateLogged = o.LoggedDate,
                                      RepairStatus = o.RepairStatus,
                                      RepairedDate = o.RepairedDate,
                                      AgentRepaired = o.AgentRepaired,
                                      FaultNames = faultsGroup.Select(f => f.Fault1).ToList(),
                                      IsRepairedList = faultsGroup.Select(f => f.IsRepaired).ToList()
                                  };
                
            }
        }
        public RepairDataModel converToRepairData(object repairData)
        {
            List<FaultModel> faults = new List<FaultModel>();
            foreach (var fault in repairData.Fa)
            {
                faults.Add(new FaultModel());
            }
            return repair;
        }
        
    }
}
