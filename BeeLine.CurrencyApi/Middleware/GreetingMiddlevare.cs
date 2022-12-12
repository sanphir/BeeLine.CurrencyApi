namespace BeeLine.CurrencyApi.Middleware
{
    public class GreetingMiddlevare

    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public GreetingMiddlevare(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Greeting", "Have a nice day");
            await _next(httpContext);
        }
    }
}
