using Quote.Common.Extensions;
using Quote.Core.Entities.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quote.Core.Interfaces
{
    public interface IClientService
    {
        Task<Client> AddClientAsync(Client client);

        Task<Client> UpdateClientAsync(Client newClient, Client originalClient);

        void DeleteClientUser(int id, int addressId);

    }
}
