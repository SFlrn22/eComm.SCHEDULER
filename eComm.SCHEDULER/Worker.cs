using eComm.APPLICATION.Contracts;

namespace eComm.SCHEDULER
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IOrchestrationService _orchestrationService;

        public Worker(ILogger<Worker> logger, IOrchestrationService orchestrationService)
        {
            _logger = logger;
            _orchestrationService = orchestrationService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    (int productCount, int userCount, int ratingCount) = await _orchestrationService.OrchestrateAsync();
                    await Task.Delay(10000, stoppingToken);
                    _logger.LogCritical($"Scheduler finished working at {DateTime.Now} without problems", productCount, userCount, ratingCount);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exceptie GetProduct la {DateTime.Now}", ex.Message.ToString());
                }
            }
        }
    }
}
