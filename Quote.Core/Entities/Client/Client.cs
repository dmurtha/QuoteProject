using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Quote.Common.Extensions;
using Ardalis.GuardClauses;
using Quote.Core.Interfaces;


namespace Quote.Core.Entities.Client
{

    public class Client : BaseEntity, IAggregateRoot
    {

        public Client()
        {

        }

        public Client(int clientid, string clientname, ClientTypes clienttype, Guid guid)
        {
            Id = clientid;
            ClientName = clientname;
            ClientType = clienttype;
            ClientGuid = guid;
        }

        public Client(int clientid, string clientname, ClientTypes clienttype, Guid guid, byte[] timestamp)
        {
            Guard.Against.NullOrEmpty(Enum.GetName(typeof(ClientTypes), clienttype), nameof(ClientTypes));

            Id = clientid;
            ClientName = clientname;
            ClientType = clienttype;
            ClientGuid = guid;
            Timestamp = timestamp;
        }

        //Table Secion
        public string ClientName { get; private set; }
        //Enum Converstion

        [Column(TypeName = "nvarchar(35)")]
        public ClientTypes ClientType { get; private set; }

        public Guid ClientGuid { get; private set; }

        //Join Section 
        //One to Many Primary table need to fix this 
        //TODO
        private readonly List<ClientClientPhone> _clientphones = new List<ClientClientPhone>();
        public IReadOnlyCollection<ClientClientPhone> ClientPhones => _clientphones.AsReadOnly();

        private readonly List<ClientContact> _clientcontacts = new List<ClientContact>();
        public IReadOnlyCollection<ClientContact> ClientContacts => _clientcontacts.AsReadOnly();

        //One to One Primary table
        public ClientAddress ClientAddress { get; private set; }


        public ClientParent ClientParent { get; private set; }


        public void AddParent(int parentid, int clientid)
        {
            Guard.Against.OutOfRange(parentid, nameof(parentid), 0, int.MaxValue);
            Guard.Against.OutOfRange(clientid, nameof(clientid), 0, int.MaxValue);
            ClientParent = new ClientParent(parentid, clientid);
        }

        public void AddAddress(int clientid, byte[] timestamp, int id, string addressname, string addressstreet, string apt, string zipcode,
                    string state, string city, string country)
        {
            Guard.Against.OutOfRange(clientid, nameof(clientid), 0, int.MaxValue);
            Guard.Against.OutOfRange(id, nameof(id), 0, int.MaxValue);
            Guard.Against.NullOrEmpty(country, nameof(country));
            Guard.Against.NullOrEmpty(addressstreet, nameof(addressstreet));
            ClientAddress = new ClientAddress(clientid, timestamp, id, addressname, addressstreet, apt, zipcode,
                        state, city, country);
        }

        public void UpdateAddress(int clientid, int id, string addressname, string addressstreet, string apt, string zipcode,
            string state, string city, string country)
        {
            Guard.Against.OutOfRange(clientid, nameof(clientid), 1, int.MaxValue);
            Guard.Against.OutOfRange(id, nameof(id), 1, int.MaxValue);
            Guard.Against.NullOrEmpty(country, nameof(country));
            Guard.Against.NullOrEmpty(addressstreet, nameof(addressstreet));

            this.ClientAddress.UpdateAddress(clientid, id, addressname, addressstreet, apt, zipcode,
                        state, city, country);
        }


        public void AddAddressTypes(int id, byte[] timestamp, string enumAddressStr)
        {
            Guard.Against.NullOrEmpty(enumAddressStr, nameof(enumAddressStr));
            Guard.Against.OutOfRange(id, nameof(id), 0, int.MaxValue);
            ClientAddress.AddAddressTypes(id, timestamp, enumAddressStr);
        }



        public void UpdateClient(string clientname, string clienttype)
        {
            Guard.Against.NullOrEmpty(clientname, nameof(clientname));
            Guard.Against.NullOrEmpty(clienttype, nameof(clienttype));
            ClientName = clientname;
            ClientType = (ClientTypes)Enum.Parse(typeof(ClientTypes), clienttype);
        }

    }
}
