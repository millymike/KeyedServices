namespace BackgroundServices.Api;

public class ConsumeAppServiceHostedService : BackgroundService
{
    private readonly ILogger<ConsumeAppServiceHostedService> _logger;
    private readonly IAppService _appService;

    public ConsumeAppServiceHostedService(ILogger<ConsumeAppServiceHostedService> logger,
        [FromKeyedServices("app")] IAppService appAppService)
    {
        _logger = logger;
        _appService = appAppService;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ConsumeAppServiceHostedService is starting.");

        await DoWork(stoppingToken);
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ConsumeAppServiceHostedService is doing background work.");

        await _appService.DoWork(stoppingToken);
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ConsumeAppServiceHostedService is stopping.");

        await base.StopAsync(stoppingToken);
    }
}