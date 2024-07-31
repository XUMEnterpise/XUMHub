using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;

namespace XUMHUB.Services.IssueLogService
{
    public class IssuesToDb : IIssueLogToDB
    {
        public async Task<IList<string>> GetAllIssues()
        {
            using (var context = new DBContext())
            {
                return await context.IssueLogs.Select(x => x.Issue).ToListAsync();
            }
        }
    }
}
