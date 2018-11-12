using Quote.Core.Interfaces;
using Quote.Core.Specifications;
using Quote.Core.Entities.Client;
using Quote.Web.Interfaces;
using Quote.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Quote.Common.Extensions;
using AutoMapper;

namespace Quote.Web.Service
{
    public class ClientViewModelServices : IClientViewModelService
    {

        private readonly IAsyncClient<Client> _clientRepositoryAsync;
        private readonly IAsyncClient<ClientAddress> _addressRepositoryAsync;
        private readonly IMapper _mapper;
        private readonly IClientService _clientService;


        public ClientViewModelServices(IAsyncClient<Client> cnt, IAsyncClient<ClientAddress> ant,
            IMapper mpr,
            IClientService csv)
        {
            _clientRepositoryAsync = cnt;
            _addressRepositoryAsync = ant;
            _mapper = mpr;
            _clientService = csv;
        }


        public async Task<List<ClientDisplayViewModel>> CreateClientDisplayViewModelAsync()
        {

            var clients = await _clientRepositoryAsync.ListAsync(new ClientWithAddressSpecification());

            List<ClientDisplayViewModel> clientDisplay = new List<ClientDisplayViewModel>();

            if (clients != null)
            {

                foreach (Client c in clients)
                {
                    clientDisplay.Add(_mapper.Map<Client, ClientDisplayViewModel>(c));
                }

                return clientDisplay;
            }
            else
            {
                return null;
            }
        }

        public ClientViewModel CreateClientForUser()
        {
            ClientViewModel clientViewModel = new ClientViewModel
            {
                ClientAddress = new ClientAddressViewModel()
            };

            clientViewModel.ClientAddress.AddressLevels = new List<ClientAddressLevelViewModel>();

            foreach (AddressTypes addressType in Enum.GetValues(typeof(AddressTypes)))
            {
                clientViewModel.ClientAddress.AddressLevels.Add(new ClientAddressLevelViewModel()
                {
                    AddressType = addressType,
                    IsCheck = false
                });
            }

            return clientViewModel;
        }

        public async Task<ClientViewModel> LoadClientForUserAsync(int id, int addressid)
        {
            ClientViewModel clientViewModel = new ClientViewModel();
            clientViewModel = await LoadClientAsync(id, clientViewModel);
            clientViewModel = await LoadClientAddressAsync(addressid, clientViewModel);
            return clientViewModel;
        }


        public async Task<ClientViewModel> LoadClientAsync(int id, ClientViewModel clientViewModel)
        {
            var clientData = await _clientRepositoryAsync.GetByIdAsync(id);

            if (clientData == null)
            {
                return null;
            }

            clientViewModel = _mapper.Map<Client, ClientViewModel>(clientData);

            return clientViewModel;
        }


        public async Task<ClientViewModel> LoadClientAddressAsync(int addressid, ClientViewModel clientViewModel)
        {
            var clientData = await _addressRepositoryAsync.GetByIdAsync(new AddressWithClientSpecification(addressid));


            clientViewModel.ClientAddress = _mapper.Map<ClientAddress, ClientAddressViewModel>(clientData);

            clientViewModel.ClientAddress.AddressLevels = new List<ClientAddressLevelViewModel>();

            foreach (AddressTypes addressType in Enum.GetValues(typeof(AddressTypes)))
            {
                clientViewModel.ClientAddress.AddressLevels.Add(new ClientAddressLevelViewModel()
                {
                    Id = clientData.ClientAddressLevels.Where(c => c.ClientAddressType == addressType).Count() > 0 ?
                      clientData.ClientAddressLevels.Where(c => c.ClientAddressType == addressType).Select(c => c.Id).FirstOrDefault()
                     : 0,
                    Timestamp = clientData.ClientAddressLevels.Where(c => c.ClientAddressType == addressType).Select(c => c.Timestamp).FirstOrDefault(),
                    AddressType = addressType,
                    IsCheck = clientData.ClientAddressLevels.Where(c => c.ClientAddressType == addressType).Count() > 0 ? true : false
                });
            }
            return clientViewModel;
        }


        public async Task<Client> AddClientUserAsync(ClientViewModel clientModel)
        {
            var client = BindClientModelToClient(clientModel);
            var clientAdded = await _clientService.AddClientAsync(client);
            return clientAdded;
        }


        public void EditClientUser(ClientViewModel clientModel, ClientViewModel originalModel)
        {

            var client = BindClientModelToClient(clientModel);
            var originalClient = BindClientModelToClient(originalModel);

            var clientAdded = _clientService.UpdateClientAsync(client, originalClient);
        }

        public Client BindClientModelToClient(ClientViewModel clientModel)
        {
            var client = _mapper.Map<ClientViewModel, Client>(clientModel);
            client.AddAddress(client.Id, clientModel.ClientAddress.Timestamp, clientModel.ClientAddress.Id, clientModel.ClientAddress.AddressName, clientModel.ClientAddress.AddressStreet,
            clientModel.ClientAddress.Apt, clientModel.ClientAddress.ZipCode,
                    clientModel.ClientAddress.State, clientModel.ClientAddress.City, clientModel.ClientAddress.Country);

            foreach (ClientAddressLevelViewModel clientLevel in clientModel.ClientAddress.AddressLevels.Where(c => c.IsCheck == true))
            {
                client.AddAddressTypes(clientLevel.Id, clientLevel.Timestamp, Enum.GetName(typeof(AddressTypes), clientLevel.AddressType));
            }

            return client;
        }


    }
}
