using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmailAzureUsers.DAL.Interfaces;
using AdmailAzureUsers.Models.Models;

namespace AdmailAzureUsers.BL.Services
{
    public class AzureUsersService
    {
        private readonly IAzureUsersRepository azureUsersRepository;

        public AzureUsersService(IAzureUsersRepository _azureUsersRepository)
        {
            azureUsersRepository = _azureUsersRepository;
        }

        public object GetAzureUsers(int id)
        {
            AzureUser azureUser = azureUsersRepository.GetAzureUserById(id);
            var users = azureUsersRepository.GetGraphAzureUsers(azureUser);
            return users;
        }


    }
}
