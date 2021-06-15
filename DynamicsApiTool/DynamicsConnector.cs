using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicsApiTool
{
    public class DynamicsConnector
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private static string _authString = "https://login.microsoftonline.com/";
        private string _tenantId = "";
        private string _clientId = "";
        private string _clientSecret = "";
        private string _tenantUrl = "";

        public bool PrettyPrintJson { get; set; }

        public DynamicsConnector(IConfiguration configuration)
        {
            _tenantId = configuration.GetValue<string>("TenantId");
            _clientId = configuration.GetValue<string>("ClientId");
            _clientSecret = configuration.GetValue<string>("ClientSecret");
            _tenantUrl = configuration.GetValue<string>("TenantUrl");

            var webApiUrl = MakeBaseUrl();
            var authHeader = MakeAuthHeader(webApiUrl);

            _httpClient.BaseAddress = new Uri(webApiUrl);
            _httpClient.DefaultRequestHeaders.Authorization = authHeader;

        }

        private AuthenticationHeaderValue MakeAuthHeader(string webApiUrl)
        {
            //string username = "admin@CRM969076.onmicrosoft.com";
            //string password = "KRf3gQo9PQ";
            //string clientId = "51f81489-12ee-4a9e-aaae-a2591f45987d";

            //var userCredential = new UserCredential(/*username, password*/);


            //var authParameters = AuthenticationParameters.CreateFromResourceUrlAsync(new Uri(webApiUrl)).Result;
            //var authContext = new AuthenticationContext(authParameters.Authority, false);
            //var authResult = authContext.AcquireToken("https://org157f11de.api.crm.dynamics.com", clientId, userCredential);
            //var authHeader = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

            // Creates a context for login.microsoftonline.com (Azure AD common authentication)
            var authContextUrl = $"{_authString}{_tenantId}";
            var authContext = new AuthenticationContext(authContextUrl);
       
            // Creates a credential from the client id and secret
            var clientCredentials = new ClientCredential(_clientId, _clientSecret);

            // Requests a bearer token
            var authResult = authContext.AcquireTokenAsync(_tenantUrl, clientCredentials).Result;

            return new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
        }

        private string MakeBaseUrl()
        {
            string url = _tenantUrl;
            string apiVersion = "9.2";
            string webApiUrl = $"{url}/api/data/v{apiVersion}/";
            return webApiUrl;
        }

        private void PrettyPrint(string json)
        {
            var jobj = JObject.Parse(json);
            Console.WriteLine(jobj.ToString());
        }

        private string GetResponseString(string uri)
        {

            Console.WriteLine("Sending request (HTTP GET)...", uri);
            Console.WriteLine(uri);

            var response = _httpClient.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Request successful.");

                //Get the response content and parse it.  
                string responseBody = response.Content.ReadAsStringAsync().Result;
                if (PrettyPrintJson)
                {
                    PrettyPrint(responseBody);
                }
                return responseBody;
            }
            else
            {
                Console.WriteLine("The request failed with a status of '{0}'", response.ReasonPhrase);
                return null;
            }
        }

        public DynamicsResponse<T> Get<T>(string uri)
        {
            var responseBody = GetResponseString(uri);
            return JsonConvert.DeserializeObject<DynamicsResponse<T>>(responseBody);
        }

        public JObject GetJObject(string uri)
        {
            var responseBody = GetResponseString(uri);
            return JObject.Parse(responseBody);
          }

        private HttpRequestMessage CreateHttpRequestMessage(string method, string uri)
        {
            var webApiUrl = MakeBaseUrl();
            var authHeader = MakeAuthHeader(webApiUrl);

            var requestMessage = new HttpRequestMessage(new HttpMethod(method), uri);
            requestMessage.Headers.Authorization = authHeader;

            return requestMessage;
        }

        private void AddJsonContentForRequest(HttpRequestMessage requestMessage, object payload)
        {
            var payloadString = JsonConvert.SerializeObject(payload);

            requestMessage.Content = new StringContent(payloadString);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        }

        public void Patch(string uri, object payload)
        {

            using (var requestMessage = CreateHttpRequestMessage("PATCH", uri))
            {
                AddJsonContentForRequest(requestMessage, payload);

                requestMessage.Headers.Add("Prefer", "return=representation");

                Console.WriteLine("Sending update (HTTP PATCH)...");

                var response = _httpClient.SendAsync(requestMessage).Result;

                string responseBody = response.Content.ReadAsStringAsync().Result;
                if (PrettyPrintJson)
                {
                    Console.WriteLine(responseBody);
                }

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Update successful.");
                }
            }
        }
    }
}