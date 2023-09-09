namespace BackgroundServices.Api;

public interface IAppService
{
    Task DoWork(CancellationToken stoppingToken);
}