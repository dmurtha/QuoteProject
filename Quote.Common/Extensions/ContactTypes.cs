using System.ComponentModel;



namespace Quote.Common.Extensions
{

    public enum ContactTypes
    {
        Primary = 1,
        CEO = 2,
        President = 3,
        [Description("Travel Agent")]
        TravelAgent = 4,
        Accounting = 5,
        Sales = 6
    }

}

