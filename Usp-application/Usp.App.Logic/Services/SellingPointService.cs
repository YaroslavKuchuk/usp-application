using Newtonsoft.Json;
using System.Net.Http.Json;
using Usp.App.Logic.Services.Abstractions;
using Usp.Models;

namespace Usp.App.Logic.Services
{
    public class SellingPointService : ISellingPointService
    {
        private readonly HttpClient _httpClient;

        public SellingPointService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("UspApi");
        }

        public async Task<List<SellingPointViewModel>> GetSellingPoints()
        {
            var responseMessage = await _httpClient.GetAsync("/api/sellingpoints");

            if (!responseMessage.IsSuccessStatusCode)
                throw new InvalidOperationException("An exception during the data retrieving");

            string content
                = await responseMessage.Content.ReadAsStringAsync();

            var sellingPointList
                = JsonConvert.DeserializeObject<List<SellingPointViewModel>>(content);
            
            return sellingPointList;
        }
    }
}
