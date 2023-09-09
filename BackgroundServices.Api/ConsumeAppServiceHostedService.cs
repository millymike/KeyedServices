namespace BackgroundServices.Api;

public class ConsumeAppServiceHostedService : BackgroundService
{
    private readonly ILogger<ConsumeAppServiceHostedService> _logger;
    public IAppService AppService { get; }

    public ConsumeAppServiceHostedService(ILogger<ConsumeAppServiceHostedService> logger,
        [FromKeyedServices("app")] IAppService appAppService)
    {
        _logger = logger;
        AppService = appAppService;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ConsumeAppServiceHostedService is starting.");

        await DoWork(stoppingToken);
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ConsumeAppServiceHostedService is doing background work.");

        await AppService.DoWork(stoppingToken);
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ConsumeAppServiceHostedService is stopping.");

        await base.StopAsync(stoppingToken);
    }
}