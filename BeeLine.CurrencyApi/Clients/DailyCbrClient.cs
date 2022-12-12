using BeeLine.CurrencyApi.Dto;
using BeeLine.CurrencyApi.Options;
using Microsoft.Extensions.Options;

namespace BeeLine.CurrencyApi.Clients
{
    public class DailyCbrClient : IDailyCbrClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ClientsOptions _clientsOptions;
        private readonly Uri _uri;
        public DailyCbrClient(IHttpClientFactory httpClientFactory, IOptions<ClientsOptions> clientsOptions)
        {
            _httpClientFactory = httpClientFactory;
            _clientsOptions = clientsOptions.Value;
            _uri = new Uri(_clientsOptions.Urls.DailyCbr);
        }

        public async Task<DailyCbrResponse> GetDailyCbr()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_uri);
            return await response.Content.ReadFromJsonAsync<DailyCbrResponse>();
        }
    }
}
