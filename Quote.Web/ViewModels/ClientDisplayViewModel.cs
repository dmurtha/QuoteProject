using Quote.Common.Extensions;
using System;

namespace Quote.Web.ViewModels
{
    public class ClientDisplayViewModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public ClientTypes ClientType { get; set; }
        public Guid ClientGuid { get; set; }
        public string AddressName { get; set; }
        public int AddressId { get; set; }
    }
}
