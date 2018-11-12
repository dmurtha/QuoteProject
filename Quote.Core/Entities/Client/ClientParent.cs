using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quote.Core.Entities;


namespace Quote.Core.Entities.Client
{
    public class ClientParent : BaseEntity
    {
        public int ParentId { get; private set; }
        public int ClientId { get; private set; }
        private Client Client { get; set; }

        public ClientParent() {}

        public ClientParent(int parentid, int clientid)
        {
            ParentId = parentid;
            ClientId = clientid;
        }
    }
}
