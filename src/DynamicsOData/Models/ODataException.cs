using System;

namespace DynamicsOData.Models
{
    public class ODataException : Exception
    {
        public ODataException(string message) : base(message)
        {
        }
    }
}
