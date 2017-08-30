using DynamicsOData.Data;
using DynamicsOData.Models;
using DynamicsOData.Models.DynamicsEntities;
using DynamicsOData.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicsOData.Test.Services
{
    [TestClass]
    public class LockEntityServiceTest
    {
        private const string LockedCustomerId = "LockedCustomerId";
        private const string UnlockedCustomerId = "UnlockedCustomerId";
        private const string OldLockCustomerId = "OldLockCustomerId";
        private const string NoRegisterdCustomerId = "NoRegisterdCustomerId";

        private const string LockedUser = "LockedUser";
        private const string UnlockedUser = "UnlockedUser";

        [TestMethod]
        public async Task ShouldThrowException()
        {
            Exception expectedException = null;

            // Arrange
            var mockedContext = GetApplicationDbContext();

            var service = new LockEntityService(mockedContext);

            // Act
            try
            {
                await service.CheckLock<Customer>(LockedCustomerId, UnlockedUser);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            // Assert
            Assert.IsInstanceOfType(expectedException, typeof(LockEntityException));
        }

        [TestMethod]
        public async Task ShouldNotThrowException_NoLock()
        {
            // Arrange
            var mockedContext = GetApplicationDbContext();

            var service = new LockEntityService(mockedContext);

            // Act
            await service.CheckLock<Customer>(NoRegisterdCustomerId, UnlockedUser);

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task ShouldNotThrowException_OldLock()
        {
            // Arrange
            var mockedContext = GetApplicationDbContext();

            var service = new LockEntityService(mockedContext);

            // Act
            await service.CheckLock<Customer>(OldLockCustomerId, UnlockedUser);

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task ShouldNotThrowException_UnlockedRegister()
        {
            // Arrange
            var mockedContext = GetApplicationDbContext();

            var service = new LockEntityService(mockedContext);

            // Act
            await service.CheckLock<Customer>(UnlockedCustomerId, UnlockedUser);

            // Assert
            Assert.IsTrue(true);
        }

        private static DynamicsDbContext GetApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<DynamicsDbContext>()
                .UseInMemoryDatabase(databaseName: "ApplicationDbContext")
                .Options;

            var db = new DynamicsDbContext(options);

            db.LockEntities.RemoveRange(db.LockEntities);
            db.SaveChanges();

            db.LockEntities.AddRange(new List<LockEntity> {
                new LockEntity { EntityId = LockedCustomerId, EntityName = "Customer", IsLocked = true, LastLockTime = DateTime.UtcNow, LastUserId = LockedUser },
                new LockEntity { EntityId = UnlockedCustomerId, EntityName = "Customer", IsLocked = false, LastLockTime = DateTime.UtcNow, LastUserId = LockedUser },
                new LockEntity { EntityId = OldLockCustomerId, EntityName = "Customer", IsLocked = true, LastLockTime = DateTime.UtcNow.AddMinutes(-35), LastUserId = LockedUser }
            });

            db.SaveChanges();

            return db;
        }
    }
}
