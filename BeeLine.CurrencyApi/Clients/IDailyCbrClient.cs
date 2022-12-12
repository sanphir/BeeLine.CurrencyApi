using BeeLine.CurrencyApi.Dto;

namespace BeeLine.CurrencyApi.Clients
{
    public interface IDailyCbrClient
    {
        Task<DailyCbrResponse> GetDailyCbr();
    }
}