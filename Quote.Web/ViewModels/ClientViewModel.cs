using Microsoft.AspNetCore.Mvc.ModelBinding;
using Quote.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Quote.Web.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public byte[] Timestamp { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        public Guid ClientGuid { get; set; }
        [Required]
        [Display(Name = "Client Type")]
        public ClientTypes ClientType { get; set; }
        public ClientAddressViewModel ClientAddress { get; set; }

    }
}
