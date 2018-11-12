using System;
using System.ComponentModel.DataAnnotations.Schema;
using Quote.Common.Extensions;
using Quote.Core.Entities;



namespace Quote.Core.Entities.Client
{


    public class ClientAddressLevel : BaseEntity
    {

        public ClientAddressLevel() { }

        public ClientAddressLevel(int id, byte[] timestamp, string addresslevel)
        {
            Id = id;
            Timestamp = timestamp;
            ClientAddressType = (AddressTypes)Enum.Parse(typeof(AddressTypes), addresslevel);
        }

        [Column(TypeName = "nvarchar(35)")]

        public AddressTypes ClientAddressType { get; private set; }

        //JOIN Section
        [ForeignKey("ClientForeignKey")]
        public int ClientAddressId { get; set; }
        public ClientAddress ClientAddress { get; set; }

    }
}
