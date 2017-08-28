using System;
using System.ComponentModel.DataAnnotations;

namespace DynamicsOData.Models.DynamicsEntities
{
    public class LockEntity
    {
        [Key]
        public int Id { get; set; }

        public string EntityName { get; set; }
        public string EntityId { get; set; }
        public string LastUserId { get; set; }
        public DateTime LastLockTime { get; set; }
        public bool IsLocked { get; set; }
    }
}
