namespace eComm.APPLICATION.Contracts
{
    public interface IOrchestrationService
    {
        Task<(int, int, int)> OrchestrateAsync();
    }
}
