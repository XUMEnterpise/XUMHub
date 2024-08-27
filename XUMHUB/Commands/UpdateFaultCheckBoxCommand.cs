using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Services.FaultsService;

namespace XUMHUB.Commands
{
    public class UpdateFaultCheckBoxCommand : AsyncCommandBase
    {
        public int FauId { get; }
        public bool IsRepaired { get; }
        IDatabaseToFaults databaseToFaults = new DatabaseToFaults();

        public UpdateFaultCheckBoxCommand(int fauId, bool isRepaired)
        {
            FauId = fauId;
            IsRepaired = isRepaired;
        }

        public override Task ExecuteAsync(object parameter)
        {
            return databaseToFaults.UpdateSpecificFault(FauId, IsRepaired);
        }
    }
}
