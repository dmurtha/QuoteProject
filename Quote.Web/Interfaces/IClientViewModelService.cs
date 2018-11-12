using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quote.Core.Entities.Client;
using Quote.Web.ViewModels;

namespace Quote.Web.Interfaces
{
    public interface IClientViewModelService
    {
        Task<List<ClientDisplayViewModel>> CreateClientDisplayViewModelAsync();

        ClientViewModel CreateClientForUser();

        Task<Client> AddClientUserAsync(ClientViewModel clientModel);

        Task<ClientViewModel> LoadClientForUserAsync(int id, int addressid);

        Task<ClientViewModel> LoadClientAsync(int Id, ClientViewModel clientViewModel);

        Task<ClientViewModel> LoadClientAddressAsync(int addressid, ClientViewModel clientViewModel);

        Client BindClientModelToClient(ClientViewModel clientModel);

        void EditClientUser(ClientViewModel clientModel, ClientViewModel originalModel);

    }
}
