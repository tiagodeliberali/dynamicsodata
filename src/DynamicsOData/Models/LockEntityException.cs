using System;

namespace DynamicsOData.Models
{
    public class LockEntityException : Exception
    {
        public LockEntityException(string message) : base(message)
        {
        }
    }
}
