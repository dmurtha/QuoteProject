using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quote.Common.Extensions;
using Quote.Core.Entities;
using Ardalis.GuardClauses;


namespace Quote.Core.Entities.Client
{
 
    public class ClientClientPhone : BaseEntity
    {
        //Table Section
        [Phone]
        [Required]
        public int PhoneNumber { get; set; }

        //Enum Convertion
        [Column(TypeName = "nvarchar(35)")]
        public PhoneTypes PhoneType { get; set; }

        //JOIN Section
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
