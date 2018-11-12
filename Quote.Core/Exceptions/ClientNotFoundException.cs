using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quote.Core.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(int clientId) : base($"No client found with id {clientId}")
        {
        }

        protected ClientNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public ClientNotFoundException(string message) : base(message)
        {
        }

        public ClientNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
