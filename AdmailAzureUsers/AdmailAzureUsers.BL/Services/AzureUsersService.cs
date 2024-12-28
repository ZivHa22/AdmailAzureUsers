using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmailAzureUsers.DAL.Interfaces;
using AdmailAzureUsers.DAL.Respositories;
using AdmailAzureUsers.Models.Models;
using Microsoft.Graph.Models;

namespace AdmailAzureUsers.BL.Services
{
    public class AzureUsersService
    {
        private readonly IAzureUsersRepository azureUsersRepository;

        public AzureUsersService(IAzureUsersRepository _azureUsersRepository)
        {
            azureUsersRepository = _azureUsersRepository;
        }

        public async Task<object> GetAzureUsers(string domain)
        {
            AzureUser azureUser = azureUsersRepository.GetAzureUserByDomain(domain);
            if (azureUser == null)
            {
                throw new Exception("The domain no exist");
            }
            azureUsersRepository.SetAzureUser(azureUser);
            var users = await azureUsersRepository.GetGraphAzureUsers();
            return users;
        }
        public async Task<object> GetAzureGroups(string domain)
        {
            AzureUser azureUser = azureUsersRepository.GetAzureUserByDomain(domain);
            if (azureUser == null)
            {
                throw new Exception("The domain no exist");
            }
            azureUsersRepository.SetAzureUser(azureUser);
            var groups = await azureUsersRepository.GetGraphAzureGroups();
            return groups;
        }


    }
}
