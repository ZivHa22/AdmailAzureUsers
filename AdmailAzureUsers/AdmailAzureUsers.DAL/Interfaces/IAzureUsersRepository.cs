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
        public AzureUser GetAzureUserById(int id);

        public Task<object> GetGraphAzureUsers(AzureUser azureUser);
    }
}
