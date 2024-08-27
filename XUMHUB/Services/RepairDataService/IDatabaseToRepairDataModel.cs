using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.Services.RepairDataService
{
    interface IDatabaseToRepairDataModel
    {
        public Task<IEnumerable<RepairDataModel>> GetAllRepairs();
        public Task<RepairDataModel> GetRepair(int repairId);
        public Task<int> CreateRepairEntry(RepairDataModel repairDataModel);
    }
}
