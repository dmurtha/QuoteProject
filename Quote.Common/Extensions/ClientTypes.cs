using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace Quote.Common.Extensions
{
    public enum ClientTypes
    {
        [Display(Name = "Location")]
        Location = 1,
        [Display(Name = "Agency")]
        Agency = 2,
        [Display(Name = "Master Agency")]
        MasterAgency = 3
    }

}
