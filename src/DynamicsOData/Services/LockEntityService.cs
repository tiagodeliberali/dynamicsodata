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
        private ApplicationDbContext db;

        public LockEntityService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task ReleaseLock(string entityName, string entityId, string userId)
        {
            var entityLock = await db.LockEntities.FirstOrDefaultAsync(x => x.EntityName == entityName && x.EntityId == entityId);

            if (entityLock == null)
            {
                return;
            }

            if (entityLock.IsLocked && entityLock.LastUserId != userId)
            {
                throw new LockEntityException($"Entity locked to another user: '{entityLock.LastUserId}'");
            }

            entityLock.IsLocked = false;

            await db.SaveChangesAsync();
        }

        public async Task<bool> RequestLock(string entityName, string entityId, string userId)
        {
            var isLocked = false;

            var entityLock = await db.LockEntities.FirstOrDefaultAsync(x => x.EntityName == entityName && x.EntityId == entityId);

            if (entityLock == null)
            {
                entityLock = new LockEntity()
                {
                    EntityId = entityId,
                    EntityName = entityName,
                    IsLocked = true,
                    LastUserId = userId,
                    LastLockTime = DateTime.UtcNow
                };

                db.Add(entityLock);

                isLocked = true;
            }
            else if (entityLock.LastUserId == userId)
            {
                isLocked = true;
            }
            else if (!entityLock.IsLocked)
            {
                entityLock.IsLocked = true;
                entityLock.LastUserId = userId;
                entityLock.LastLockTime = DateTime.UtcNow;

                isLocked = true;
            }
            else
            {
                isLocked = false;
            }

            await db.SaveChangesAsync();
            return isLocked;
        }
    }
}
