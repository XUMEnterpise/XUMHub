using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;

namespace XUMHUB.Services.IssuesService
{
    class DatabaseToIssueLog : IDatabaseToIssueFault
    {
        public Task UpdateIssueFault(string f)
        {
            using(var db = new DBContext())
            {
                var fault = db.IssueLogs.AddAsync(new IssueLog
                {
                    Issue = f
                });
                return db.SaveChangesAsync();
                
            }
        }
    }
}
