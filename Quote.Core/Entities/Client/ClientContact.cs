using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quote.Core.Entities;


namespace Quote.Core.Entities.Client
{

    public class ClientContact : BaseEntity
    {
        
        public string ClientFistName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientTitle { get; set; }


        [EmailAddress]
        public string EmailAddress { get; set; }

        //Join Section

        //One to Many Dependent
        public int ClientId { get; set; }
        public Client Client { get; set; }

        //One to Many Primary
        public IEnumerable<ClientClientPhone> ClientPhones { get; set; }
        public IEnumerable<ClientContactLevel> ClientContactTypes { get; set; }

    }
}
