using BackgroundServices.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<HostOptions>(x =>
{
    x.ServicesStartConcurrently = true;
    x.ServicesStopConcurrently = false;
});

builder.Services.AddHostedService<ConsumeAppServiceHostedService>();
builder.Services.AddKeyedSingleton<IAppService, AppService>("app");


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();