namespace BackgroundServices.Api;

public class AppBackgroundService : IHostedLifecycleService
{
    private readonly ILogger<AppBackgroundService> _logger;
    private readonly IAppService _appService;

    public AppBackgroundService(ILogger<AppBackgroundService> logger, [FromKeyedServices("app")] IAppService appService)
    {
        _logger = logger;
        _appService = appService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("start AppBackgroundService");
        await _appService.DoWork(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("stop AppBackgroundService");
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("started AppBackgroundService");
        return Task.CompletedTask;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("starting AppBackgroundService");
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("stopped AppBackgroundService");
        return Task.CompletedTask;    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("stopping AppBackgroundService");
        return Task.CompletedTask;    }
}