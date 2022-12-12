using BeeLine.CurrencyApi.Clients;
using BeeLine.CurrencyApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BeeLine.CurrencyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly IDailyCbrClient _client;
        public CurrencyController(IDailyCbrClient client)
        {
            _client = client;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Response<CurrencyInfo>>> Get(string name)
        {
            var dailyCbrResult = await _client.GetDailyCbr();
            var currencyName = name.ToUpper();
            if (!dailyCbrResult.Valute.ContainsKey(currencyName))
            {
                return NotFound(new Response<CurrencyInfo>
                {
                    IsSuccess = false,
                    ErrorMessage = $"Currency \"{currencyName}\" not found"
                });
            }

            return Ok(new Response<CurrencyInfo>
            {
                IsSuccess = true,
                Data = dailyCbrResult.Valute[currencyName]
            });
        }
    }
}
