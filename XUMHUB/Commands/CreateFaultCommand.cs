using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;
using XUMHUB.Services.FaultsService;
using XUMHUB.ViewModel;

namespace XUMHUB.Commands
{
    public class CreateFaultCommand : AsyncCommandBase
    {
        private FaultViewModel Fault;
        IDatabaseToFaults databaseToFaults = new DatabaseToFaults();
        public CreateFaultCommand(FaultViewModel fault)
        {
            Fault = fault;
        }

        public override Task ExecuteAsync(object parameter)
        {

            FaultModel faultModel = new FaultModel(null, Fault.repairId, Fault.FaultName, Fault.IsRepaired);
            return databaseToFaults.UpdateFaults(faultModel);
        }
    }
}
