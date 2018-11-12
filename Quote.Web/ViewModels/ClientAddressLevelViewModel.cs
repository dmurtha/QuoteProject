using System.ComponentModel.DataAnnotations;
using Quote.Common.Extensions;
using System;

namespace Quote.Web.ViewModels
{
    public class ClientAddressLevelViewModel
    {


        public int Id { get; set; }
        public byte[] Timestamp { get; set; }

        [Display(Name = "Address Type")]
        public AddressTypes AddressType { get; set; }
        public bool IsCheck { get; set; }


    }
}
