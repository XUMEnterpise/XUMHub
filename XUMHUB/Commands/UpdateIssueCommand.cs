using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Services.IssuesService;

namespace XUMHUB.Commands
{
    class UpdateIssueCommand : AsyncCommandBase
    {
        private string Issue;
        public UpdateIssueCommand(string issue)
        {
            Issue = issue;
        }

        public override Task ExecuteAsync(object parameter)
        {
            IDatabaseToIssueFault databaseToIssueFault = new DatabaseToIssueLog();
            return databaseToIssueFault.UpdateIssueFault(Issue);
        }
    }
}
