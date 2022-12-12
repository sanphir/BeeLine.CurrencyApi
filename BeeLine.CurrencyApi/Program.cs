using BeeLine.CurrencyApi.Clients;
using BeeLine.CurrencyApi.Middleware;
using BeeLine.CurrencyApi.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDailyCbrClient, DailyCbrClient>();
builder.Services.Configure<ClientsOptions>(builder.Configuration.GetSection("Clients"));

var clientsOpttions = builder.Configuration.GetSection("Clients").Get<ClientsOptions>();
builder.Services.AddHttpClient(nameof(DailyCbrClient),
    client =>
    {
        client.BaseAddress = new Uri(clientsOpttions.Urls.DailyCbr);
    })
    .AddTransientHttpErrorPolicy(plicyBuilder => plicyBuilder.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(2), 5)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GreetingMiddlevare>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
