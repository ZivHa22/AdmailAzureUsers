using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdmailAzureUsers.DAL
{
    public class HttpHelper
    {
        private IConfiguration Configuration { get; }
        private HttpClient client;
        private string baseUrl;
        public HttpHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            client = new HttpClient();
            // baseUrl = configuration.GetSection("OTP").GetSection("BaseUrl").Value;
        }
        public async Task<string> Get(string url, Dictionary<string, string>? headers)
        {
            try
            {

                client.DefaultRequestHeaders.Clear();
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var readAsString = response.Content.ReadAsStringAsync().Result;
                    return readAsString;
                }
                else
                {
                    Exception e = new Exception("Error in http request to " + url + ". Status code: " + response.StatusCode);
                    throw e;
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<HttpResponseMessage> Post(string url, object data, Dictionary<string, string>? headers)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var json = JsonConvert.SerializeObject(data);
                var dataObj = new StringContent(json, Encoding.UTF8, "application/json");
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync(url, dataObj).Result;
                return response;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
