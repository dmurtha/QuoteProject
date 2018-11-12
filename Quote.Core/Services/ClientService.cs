using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quote.Core.Interfaces;
using Quote.Core.Entities.Client;
using Quote.Common.Extensions;
using Quote.Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Quote.Core.Services
{
    public class ClientService : IClientService
    {

        private readonly IAsyncClient<Client> _clientRepositoryAsync;
        private readonly IClient<Client> _clientRepository;
        private readonly IAsyncClient<ClientAddressLevel> _addressTypeRepositoryAsync;
        private readonly IClient<ClientAddressLevel> _addressTypeRepository;
        private readonly IAsyncClient<ClientAddress> _addressRepositoryAsync;
        private readonly IClient<ClientAddress> _addressRepository;

        public ClientService(IAsyncClient<Client> cnta, IClient<Client> cnt, IAsyncClient<ClientAddress> ant,
            IAsyncClient<ClientAddressLevel> cdl,
            IClient<ClientAddress> cds,
            IClient<ClientAddressLevel> cal
            )
        {
            _clientRepositoryAsync = cnta;
            _clientRepository = cnt;
            _addressRepositoryAsync = ant;
            _addressTypeRepositoryAsync = cdl;
            _addressRepository = cds;
            _addressTypeRepository = cal;
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            await _clientRepositoryAsync.AddAsync(client);
            return client;
        }

        public async Task<Client> UpdateClientAsync(Client newClient, Client originalClient)
        {
            if (originalClient.Id == 0)
            {
                originalClient = await _clientRepositoryAsync.GetByIdAsync(newClient.Id);



                var clientData = await _addressRepositoryAsync.GetByIdAsync(new AddressWithClientSpecification(newClient.ClientAddress.Id));

                originalClient.AddAddress(newClient.Id, clientData.Timestamp, clientData.Id, clientData.AddressName, clientData.AddressStreet,
                            clientData.Apt, clientData.ZipCode,
                            clientData.State, clientData.City, clientData.Country);

                foreach (ClientAddressLevel clientLevel in clientData.ClientAddressLevels)
                {
                    originalClient.AddAddressTypes(clientLevel.Id, clientLevel.Timestamp, Enum.GetName(typeof(AddressTypes), clientLevel.ClientAddressType));
                }

            }
            else
            {
                _clientRepositoryAsync.Attach(originalClient);
            }


            originalClient.UpdateClient(newClient.ClientName, Enum.GetName(typeof(ClientTypes), newClient.ClientType));
            originalClient.UpdateAddress(newClient.Id, newClient.ClientAddress.Id, newClient.ClientAddress.AddressName,
                newClient.ClientAddress.AddressStreet, newClient.ClientAddress.Apt, newClient.ClientAddress.ZipCode,
                newClient.ClientAddress.State, newClient.ClientAddress.City, newClient.ClientAddress.Country);

            foreach (ClientAddressLevel clientLevel in newClient.ClientAddress.ClientAddressLevels)
            {
                if (originalClient.ClientAddress.ClientAddressLevels.Where(e => e.ClientAddressType == clientLevel.ClientAddressType).Count() == 0)
                {
                    originalClient.AddAddressTypes(clientLevel.Id, clientLevel.Timestamp, Enum.GetName(typeof(AddressTypes), clientLevel.ClientAddressType));
                }
            }
            foreach (ClientAddressLevel clientLevel in originalClient.ClientAddress.ClientAddressLevels)
            {
                if (newClient.ClientAddress.ClientAddressLevels.Where(e => e.ClientAddressType == clientLevel.ClientAddressType).Count() == 0)
                {
                    _addressTypeRepositoryAsync.SetDelete(originalClient.ClientAddress.ClientAddressLevels.Where(e => e.Id == clientLevel.Id).FirstOrDefault());
                }
            }
            await _clientRepositoryAsync.UpdateAsync(originalClient);
            return originalClient;

        }

        public void DeleteClientUser(int id, int addressId)
        {
            var clientAddressData = _addressRepository.GetById(new AddressWithClientSpecification(addressId));
            var client = _clientRepository.GetById(id);

            _addressTypeRepository.DeleteRange(clientAddressData.ClientAddressLevels.ToList());
            _addressRepository.Delete(clientAddressData);
            _clientRepository.Delete(client);
        }


    }
}
