using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;
using XUMHUB.Services.AgentService;
using XUMHUB.Services.RepairDataService;
using XUMHUB.ViewModel;

namespace XUMHUB.Commands
{
    public class CreateRepairEntryCommand : AsyncCommandBase
    {
        RepairEntryViewModel RepairViewModel;
        IDatabaseToAgent databaseToAgent = new DatabaseToAgent();
        IDatabaseToRepairDataModel databaseToRepairDataModel = new DatabaseToRepairDataModel();

        public CreateRepairEntryCommand(RepairEntryViewModel repairViewModel)
        {
            RepairViewModel = repairViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
           List<FaultModel> faults = ConvertToFaults(RepairViewModel.Faults);
            RepairDataModel repairDataModel = new RepairDataModel(null,RepairViewModel.ServiceTag,databaseToAgent.GetAgentByName(RepairViewModel.Agent),RepairViewModel.LoggedDate
               ,RepairViewModel.RepairStatus,RepairViewModel.RepairDate,databaseToAgent.GetAgentByName(RepairViewModel.RepairAgent),faults,null);
            int repairID= await databaseToRepairDataModel.CreateRepairEntry(repairDataModel);
            foreach (var fault in faults)
            {
                
                await new CreateFaultCommand(new FaultViewModel(null,repairID,fault.FaultName,fault.IsRepaired??false)).ExecuteAsync(null);
            }

        }
        private List<FaultModel> ConvertToFaults(List<FaultViewModel> fault)
        {
            List<FaultModel> faults = new List<FaultModel>();
            foreach (var f in fault)
            {
                FaultModel faultModel = new FaultModel(f.faultId, f.repairId, f.FaultName, f.IsRepaired);
                faults.Add(faultModel);
            }
            return faults;
        }
    }
}
