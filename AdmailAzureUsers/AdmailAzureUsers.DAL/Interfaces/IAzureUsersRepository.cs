using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmailAzureUsers.Models.Models;

namespace AdmailAzureUsers.DAL.Interfaces
{
    public interface IAzureUsersRepository
    {
        public AzureUser GetAzureUserByDomain(string domain);

        public Task<object> GetGraphAzureUsers();
        public Task<object> GetGraphAzureGroups();
        public void SetAzureUser(AzureUser azureUser);
    }
}
