using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quote.Common.Extensions
{
    public enum AddressTypes
    {
        [Display(Name = "Head Office")]
        HeadOffice = 1,
        [Display(Name = "Additional Office")]
        AdditionalOffice = 2,
        [Display(Name = "Mail Stop")]
        MailStop = 3,
        [Display(Name = "Payment Address")]
        PaymentAddress = 4,
        [Display(Name = "Other")]
        Other = 5
    }

}
