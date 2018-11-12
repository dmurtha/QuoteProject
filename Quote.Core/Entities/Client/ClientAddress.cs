using System.Collections.Generic;
using Quote.Common.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using System;

namespace Quote.Core.Entities.Client
{

    public class ClientAddress : BaseEntity
    {

        public ClientAddress() { }

        public ClientAddress(int clientid, byte[] timestamp, int id, string addressname, string addressstreet, string apt,
            string zipcode, string state, string city, string country)
        {
            ClientId = clientid;
            Timestamp = timestamp;
            Id = id;
            AddressName = addressname;
            AddressStreet = addressstreet;
            Apt = apt;
            ZipCode = zipcode;
            State = state;
            City = city;
            Country = country;
        }

        //Table Section
        public string AddressName { get; private set; }
        public string AddressStreet { get; private set; }
        public string Apt { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }


        //Join Section
        //One to one Dependent
        public int ClientId { get; private set; }
        public Client Client { get; set; }

        //One to many 
        private readonly List<ClientAddressLevel> _clientaddresslevels = new List<ClientAddressLevel>();
        public IReadOnlyCollection<ClientAddressLevel> ClientAddressLevels => _clientaddresslevels;

        public void AddAddressTypes(int id, byte[] timestamp, string addresstype)
        {
            _clientaddresslevels.Add(new ClientAddressLevel(id, timestamp, addresstype));
        }

        public void UpdateAddress(int clientid, int id, string addressname, string addressstreet, string apt,
                string zipcode, string state, string city, string country)
        {
            AddressName = addressname;
            AddressStreet = addressstreet;
            Apt = apt;
            ZipCode = zipcode;
            State = state;
            City = city;
            Country = country;
        }
    }
}
