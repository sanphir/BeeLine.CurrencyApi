using BeeLine.CurrencyApi.Dto;

namespace BeeLine.CurrencyApi.Clients
{
    public class DailyCbrClient : IDailyCbrClient
    {
        private const string DAILY_CBR_URI_PATH = "daily_json.js";
        private readonly IHttpClientFactory _httpClientFactory;

        public DailyCbrClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<DailyCbrResponse> GetDailyCbr()
        {
            var client = _httpClientFactory.CreateClient(nameof(DailyCbrClient));

            var response = await client.GetAsync(DAILY_CBR_URI_PATH);
            return await response.Content.ReadFromJsonAsync<DailyCbrResponse>();
        }
    }
}
