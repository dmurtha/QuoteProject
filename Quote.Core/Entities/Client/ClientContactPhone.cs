using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quote.Core.Entities;
using Quote.Common.Extensions;


namespace Quote.Core.Entities.Client
{

    public class ClientContactPhone : BaseEntity
    {
        //Table Section
        [Phone]
        [Required]
        public int PhoneNumber { get; set; }

        //Enum Convertion
        [Column(TypeName = "nvarchar(35)")]
        public PhoneTypes PhoneType { get; set; }

        //JOIN Section
        public long ClientContactId { get; set; }
        public ClientContact ClientContact { get; set; }
    }
}
