using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Services.IssueLogService
{
    internal interface IIssueLogToDB
    {
        public Task<IList<String>> GetAllIssues();
    }
}
