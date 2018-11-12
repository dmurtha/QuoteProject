using Quote.Core.Entities.Client;

namespace Quote.Core.Specifications
{
    public sealed class ClientWithAddressSpecification : BaseSpecification<Client>
    {
        public ClientWithAddressSpecification(int clientId)
            : base(b => b.Id == clientId)
        {
            AddInclude(b => b.ClientAddress);
        }
        public ClientWithAddressSpecification() 
            : base(b => b.Id == b.Id)
        {
            AddInclude(b => b.ClientAddress);
        }
    }
}

