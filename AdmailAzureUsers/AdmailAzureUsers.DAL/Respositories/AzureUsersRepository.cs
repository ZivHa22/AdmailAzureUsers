using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AdmailAzureUsers.DAL.DataAccess;
using AdmailAzureUsers.DAL.Interfaces;
using AdmailAzureUsers.Models.Models;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace AdmailAzureUsers.DAL.Respositories
{
    public class AzureUsersRepository : IAzureUsersRepository
    {
        AdmailAzureUsersContext context { get; }
        public AzureUsersRepository(AdmailAzureUsersContext _context)
        {
            context = _context;
        }

        public AzureUser GetAzureUserById(int id)
        {
            try
            {
                return context.AzureUsers.Where(u => u.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<object> GetGraphAzureUsers(AzureUser azureUser)
        {
            try
            {
                //string token = await GetAccessToken(azureUser);
                var clientSecretCredential = new ClientSecretCredential(azureUser.TenantId, azureUser.ClientId, azureUser.ClientSecret);

                // Use the new TokenCredentialAuthProvider
                var authProvider = new ChainedTokenCredential(clientSecretCredential);

                // Initialize GraphServiceClient
                var graphClient = new GraphServiceClient(authProvider);
                var users = await graphClient.Users.GetAsync();



                return users;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }



        private async Task<string> GetAccessToken(AzureUser azureUser)
        {
            var app = ConfidentialClientApplicationBuilder.Create(azureUser.ClientId)
                .WithClientSecret(azureUser.ClientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{azureUser.TenantId}"))
                .Build();

            string[] scopes = { "https://graph.microsoft.com/.default" };

            var authResult = await app.AcquireTokenForClient(scopes).ExecuteAsync();
            return authResult.AccessToken;
        }

    }
}
