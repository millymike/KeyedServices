namespace BackgroundServices.Api;

public class AppService : IAppService
{
    private int executioncount = 0;
    private readonly ILogger _logger;

    public AppService(ILogger<AppService> logger)
    {
        _logger = logger;
    }

    public Task DoWork(CancellationToken stoppingToken)
    {
        _logger.LogInformation("AppService is starting.");

        stoppingToken.Register(() =>
            _logger.LogInformation($"AppService is stopping. executionCount={executioncount}"));

        while (!stoppingToken.IsCancellationRequested)
        {
            executioncount++;

            _logger.LogInformation("AppService is doing background work. executionCount={executioncount}", executioncount);

            Thread.Sleep(5000);
        }

        return Task.CompletedTask;
    }
}