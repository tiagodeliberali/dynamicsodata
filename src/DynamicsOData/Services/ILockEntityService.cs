using System.Threading.Tasks;

namespace DynamicsOData.Services
{
    public interface ILockEntityService
    {
        Task ReleaseLock(string entityName, string entityId, string userId);
        Task<bool> RequestLock(string entityName, string entityId, string userId);
    }
}