using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AdmailAzureUsers.DAL.DataAccess;
using AdmailAzureUsers.DAL.Interfaces;
using AdmailAzureUsers.Models.DTO;
using AdmailAzureUsers.Models.Models;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;

namespace AdmailAzureUsers.DAL.Respositories
{
    public class AzureUsersRepository : IAzureUsersRepository
    {
        AdmailAzureUsersContext context { get; }
        private ClientSecretCredential clientSecretCredential;
        private ChainedTokenCredential authProvider;
        private GraphServiceClient graphClient;

        public AzureUsersRepository(AdmailAzureUsersContext _context)
        {
            context = _context;
        }

        public AzureUser GetAzureUserByDomain(string domain)
        {
            try
            {
                return context.AzureUsers.Where(u => u.Domain == domain).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<object> GetGraphAzureUsers()
        {
            try
            {

                var users = await graphClient.Users.GetAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<object> GetGraphAzureGroups()
        {
            List<Models.DTO.Group> groups = new List<Models.DTO.Group>();
            Models.DTO.Group group;

            try
            {
                var groupsAzure = await graphClient.Groups.GetAsync();

                foreach (var groupAzr in groupsAzure.Value)
                {
                    var members = await graphClient.Groups[groupAzr.Id].Members.GetAsync();
                    List<Member> memberList = new List<Member>();

                    foreach (var member in members.Value)
                    {
                        if (member is User user)
                        {
                            memberList.Add(new Member(user.Id,user.DisplayName,user.Mail));
                        }
                    }
                    groups.Add(new Models.DTO.Group(groupAzr.Id, groupAzr.DisplayName, memberList));                }
                return groups;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void SetAzureUser(AzureUser azureUser)
        {
            //string token = await GetAccessToken(azureUser);
            clientSecretCredential = new ClientSecretCredential(azureUser.TenantId, azureUser.ClientId, azureUser.ClientSecret);

            // Use the new TokenCredentialAuthProvider
            authProvider = new ChainedTokenCredential(clientSecretCredential);

            // Initialize GraphServiceClient
            graphClient = new GraphServiceClient(authProvider);
        }

    }
}
