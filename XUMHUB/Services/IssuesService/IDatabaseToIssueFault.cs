using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Services.IssuesService
{
    interface IDatabaseToIssueFault
    {
        Task UpdateIssueFault( string fault);
    }
}
