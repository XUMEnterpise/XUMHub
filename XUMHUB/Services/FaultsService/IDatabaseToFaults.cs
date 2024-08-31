using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.Services.FaultsService
{
    public interface IDatabaseToFaults
    {
        Task UpdateFaults(FaultModel fault);
        Task UpdateSpecificFault(int fauId, bool isRepaired,string repairedId);
        Task<string> GetFaultId(int repairId, string faultName);
    }
}
