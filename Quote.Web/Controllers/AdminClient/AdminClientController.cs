using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quote.Core.Interfaces;
using Quote.Core.Specifications;
using Quote.Web.ViewModels;
using Quote.Web.Interfaces;
using Quote.Web.Service;
using System.Linq;
using Quote.Common.Extensions;
using System;
using AutoMapper;

namespace Quote.Web.Controllers.AdminClient
{
    public class AdminClientController : Controller
    {
        private readonly IClientViewModelService _clientViewModelService;
        private readonly IClientService _clientService;



        public AdminClientController(IClientViewModelService cvm,
            IClientService csv)
        {
            _clientViewModelService = cvm;
            _clientService = csv;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {


            var clientDisplay = await _clientViewModelService.CreateClientDisplayViewModelAsync();

            if (clientDisplay != null)
            {
                return View(nameof(Index), clientDisplay);
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id, int AddressId)
        {
            var client = await _clientViewModelService.LoadClientForUserAsync(Id, AddressId);

            if (client == null)
            {
                return null;
            }

            return View("Create", client);
        }

        [HttpPost]
        public IActionResult Delete(int id, int addressId)
        {
            _clientService.DeleteClientUser(id, addressId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create", _clientViewModelService.CreateClientForUser());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewModel clientModel, ClientViewModel original)
        {
            if (!ModelState.IsValid)
            {
                return View(clientModel);
            }



            if (clientModel.Id == 0)
            {
                var client = await _clientViewModelService.AddClientUserAsync(clientModel);

            }
            else if (clientModel.Id > 0)
            {
                _clientViewModelService.EditClientUser(clientModel, original);
            }
            return RedirectToAction(nameof(Index));
        }


    }
}

