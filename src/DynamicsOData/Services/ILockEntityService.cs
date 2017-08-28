using System.Threading.Tasks;

namespace DynamicsOData.Services
{
    public interface ILockEntityService
    {
        Task ReleaseLock<T>(string entityId, string userId);
        Task RequestLock<T>(string entityId, string userId);
        Task CheckLock<T>(string entityId, string userId);
    }
}