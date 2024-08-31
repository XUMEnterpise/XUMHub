using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.Services.FaultsService
{
    public class DatabaseToFaults : IDatabaseToFaults
    {
        public async Task<string> GetFaultId(int repairId, string faultName)
        {
            using (var context = new DBContext())
            {
                Fault faultDTO = await context.Faults.FirstOrDefaultAsync(x => x.RepairId == repairId && x.Fault1 == faultName);
                if(faultDTO == null)
                {
                    return null;
                }
                return faultDTO.Id.ToString();
            }
        }

        public async Task UpdateFaults(FaultModel fault)
        {

            using (var context = new DBContext())
            {
                if (fault.RepairId == 0)
                {
                    return;
                }
                Fault faultDTO = new Fault()
                {
                    RepairId = fault.RepairId,
                    Fault1 = fault.FaultName,
                    IsRepaired = fault.IsRepaired
                };
                context.Faults.Add(faultDTO);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateSpecificFault(int fauId, bool isRepaired, string repairedId)
        {
            using (var context = new DBContext())
            {
                var fault = context.Faults.FirstOrDefault(x => x.Id == fauId);
                if (fault != null)
                {
                    fault.IsRepaired = isRepaired;
                    fault.RepairedAgent = repairedId;
                    await context.SaveChangesAsync();
                }
                else
                {
                    MessageBox.Show("Fault not found");
                }

            }
        }
    }
}
