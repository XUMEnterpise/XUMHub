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
        public async Task UpdateFaults(FaultModel fault)
        {

            using (var context = new DBContext())
            {
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

        public async Task UpdateSpecificFault(int fauId, bool isRepaired)
        {
            using (var context = new DBContext())
            {
                var fault = context.Faults.FirstOrDefault(x => x.Id == fauId);
                if (fault != null)
                {
                    fault.IsRepaired = isRepaired;
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
