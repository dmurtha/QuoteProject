using System.ComponentModel.DataAnnotations.Schema;
using Quote.Common.Extensions;
using Quote.Core.Entities;


namespace Quote.Core.Entities.Client
{


    public class ClientContactLevel : BaseEntity
    {
        [Column(TypeName = "nvarchar(35)")]
        public ContactTypes ClientContactType { get; set; }

        //JOIN Section
        public long ClientContactId { get; set; }
        public ClientContact ClientContact { get; set; }
    }
}
