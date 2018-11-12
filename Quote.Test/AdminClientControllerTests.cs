using Xunit;
using Moq;
using Quote.Web.Interfaces;
using Quote.Web.ViewModels;
using Quote.Web.Controllers.AdminClient;
using System.Threading.Tasks;
using Quote.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Quote.Core.Entities.Client;

namespace Quote.Tests
{
    public class AdminClientControllerTests
    {
        Mock<IClientViewModelService> mockClientViewService = new Mock<IClientViewModelService>();
        Mock<IClientService> mockClientService = new Mock<IClientService>();

        private List<ClientDisplayViewModel> GetTestClientDisplayViewModel()
        {
            var clientVM = new List<ClientDisplayViewModel>()
            {
                new ClientDisplayViewModel() {
                Id = 1,
                ClientName = "Test",
                ClientGuid = Guid.NewGuid(),
                ClientType = Common.Extensions.ClientTypes.MasterAgency
                },
                new ClientDisplayViewModel() {
                Id = 2,
                ClientName = "Test2",
                ClientGuid = Guid.NewGuid(),
                ClientType = Common.Extensions.ClientTypes.Agency
                }
            };
            return clientVM;
        }

        public ClientViewModel GetEditTestViewModel()
        {
            var clientVM = new ClientViewModel()
            {
                Id = 1,
                ClientName = "Test",
                ClientType = Common.Extensions.ClientTypes.Location
            };
            return clientVM;
        }

        public ClientViewModel GetAddTestViewModel()
        {
            var clientVM = new ClientViewModel()
            {
                Id = 0,
                ClientName = "Test",
                ClientType = Common.Extensions.ClientTypes.Location
            };
            return clientVM;
        }
        public Client GetTestClientModel()
        {
            var clientVM = new Client(1, "Test", Common.Extensions.ClientTypes.Location, Guid.NewGuid());
            return clientVM;
        }

        [Fact]
        public async void EditGet_AdminClient_LoadAssertTestAsync()
        {
            //Arrange
            int AGENTID = 1;
            int ADDRESSID = 1;

            mockClientViewService.Setup(x => x.LoadClientForUserAsync(AGENTID, ADDRESSID)).Returns(Task.FromResult(GetEditTestViewModel()));
            var controller = new AdminClientController(mockClientViewService.Object, mockClientService.Object);

            // Act
            var result = await controller.Edit(AGENTID, ADDRESSID);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ClientViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal("Test", model.ClientName);

        }


        [Fact]
        public async void Index_AdminClient_LoadAssertTestAsync()
        {
            //Arrange
            //var clientDisplay = await _clientViewModelService.CreateClientDisplayViewModelAsync();


            mockClientViewService.Setup(x => x.CreateClientDisplayViewModelAsync()).Returns(Task.FromResult(GetTestClientDisplayViewModel()));
            var controller = new AdminClientController(mockClientViewService.Object, mockClientService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ClientDisplayViewModel>>(
                    viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async void Create_AdminClientEdit_LoadAssertTestAsync()
        {
            //Arrange
            //Runs the Edit
            mockClientViewService.Setup(x => x.AddClientUserAsync(GetAddTestViewModel())).Returns(Task.FromResult(GetTestClientModel()));
            mockClientViewService.Setup(x => x.EditClientUser(GetEditTestViewModel(), GetEditTestViewModel()));

            var controller = new AdminClientController(mockClientViewService.Object, mockClientService.Object);

            // Act
            var result = await controller.Create(GetEditTestViewModel(), GetEditTestViewModel());

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async void Create_AdminClientAdd_LoadAssertTestAsync()
        {
            //Arrange
            //Runs the Edit
            mockClientViewService.Setup(x => x.AddClientUserAsync(GetAddTestViewModel())).Returns(Task.FromResult(GetTestClientModel()));
            mockClientViewService.Setup(x => x.EditClientUser(GetAddTestViewModel(), GetAddTestViewModel()));

            var controller = new AdminClientController(mockClientViewService.Object, mockClientService.Object);

            // Act
            var result = await controller.Create(GetAddTestViewModel(), GetAddTestViewModel());

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
