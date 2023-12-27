using LoanOffersCalculatorMAUI.Data;
using LoanOffersCalculatorMAUI.ViewModel;
using MongoDB.Bson;
using Newtonsoft.Json;
using Realms;
using Realms.Sync;
using System.Collections.Generic;

namespace LoanOffersCalculatorMAUI.Services
{
    public class AppService<T> : IAppService<T>
    {
        private string _baseUrl = "https://loanofferscalculatorapi20231207142346.azurewebsites.net/";//"https://localhost:7122/";
        private FlexibleSyncConfiguration config;
        public HttpClient _httpClient { get; }
        public AppService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(_baseUrl);

            _httpClient = httpClient;
        }

        public async Task<List<T>> GetAllAsync(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);


            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            if (responseStatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<T>>(responseBody));
            }
            else
                return null;
        }
        public async Task<T> SaveAsync(string requestUri, T obj)
        {
            string serializedUser = JsonConvert.SerializeObject(obj);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);

            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedObj = JsonConvert.DeserializeObject<T>(responseBody);

            return await Task.FromResult(returnedObj);
        }

        public async Task<bool> DeleteAsync(string requestUri, string Id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri + Id);

            var response = await _httpClient.SendAsync(requestMessage);

            return await Task.FromResult(true);
        }
    }
}
