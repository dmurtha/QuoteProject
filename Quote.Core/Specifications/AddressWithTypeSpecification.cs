using Quote.Core.Entities.Client;

namespace Quote.Core.Specifications
{
    public sealed class AddressWithClientSpecification : BaseSpecification<ClientAddress>
    {
        public AddressWithClientSpecification(int addressId)
            : base(b => b.Id == addressId)
        {
            AddInclude(b => b.ClientAddressLevels);
        }
        public AddressWithClientSpecification()
            : base(b => b.Id == b.Id)
        {
            AddInclude(b => b.ClientAddressLevels);
        }
    }
}

