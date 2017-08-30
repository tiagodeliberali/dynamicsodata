using DynamicsOData.Data;
using DynamicsOData.Models;
using DynamicsOData.Models.DynamicsEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DynamicsOData.Services
{
    public class LockEntityService : ILockEntityService
    {
        private DynamicsDbContext db;

        public LockEntityService(DynamicsDbContext db)
        {
            this.db = db;
        }

        public async Task CheckLock<T>(string entityId, string userId)
        {
            await GetValidLockEntity<T>(entityId, userId);
        }

        public async Task ReleaseLock<T>(string entityId, string userId)
        {
            var entityLock = await GetValidLockEntity<T>(entityId, userId);

            if (entityLock == null)
            {
                return;
            }

            entityLock.IsLocked = false;

            await db.SaveChangesAsync();
        }

        public async Task RequestLock<T>(string entityId, string userId)
        {
            var entityLock = await GetValidLockEntity<T>(entityId, userId);

            if (entityLock == null)
            {
                entityLock = new LockEntity()
                {
                    EntityId = entityId,
                    EntityName = typeof(T).Name,
                    IsLocked = true,
                    LastUserId = userId,
                    LastLockTime = DateTime.UtcNow
                };

                db.Add(entityLock);
            }
            else
            {
                entityLock.IsLocked = true;
                entityLock.LastUserId = userId;
                entityLock.LastLockTime = DateTime.UtcNow;
            }

            await db.SaveChangesAsync();
        }

        private async Task<LockEntity> GetValidLockEntity<T>(string entityId, string userId)
        {
            var entityLock = await db.LockEntities.FirstOrDefaultAsync(x => x.EntityName == typeof(T).Name && x.EntityId == entityId);

            if (IsLockedToAnotherUser(userId, entityLock))
                throw new LockEntityException($"Entity locked to another user: '{entityLock.LastUserId}'");

            return entityLock;
        }

        private bool IsLockedToAnotherUser(string userId, LockEntity entityLock)
        {
            return entityLock != null && entityLock.IsLocked && entityLock.LastUserId != userId && entityLock.LastLockTime < DateTime.UtcNow.AddMinutes(30);
        }
    }
}
