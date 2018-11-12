using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Quote.Web.ViewModels
{
    public class ClientAddressViewModel
    {

        public int Id { get; set; }
        public byte[] Timestamp { get; set; }

        [Required]
        [Display(Name = "Address Name")]
        public string AddressName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string AddressStreet { get; set; }

        [Display(Name = "Apartment #")]
        public string Apt { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        [Required]
        public string Country { get; set; }




        public IList<ClientAddressLevelViewModel> AddressLevels { get; set; }

        [Range(minimum: 1, maximum: Int32.MaxValue, ErrorMessage = "At least one Address Type needs to be checked")]
        public int AddressCount
        {
            get
            {
                return AddressLevels != null ? AddressLevels.Where(a => a.IsCheck == true).Count() : 0;
            }
        }

    }
}
