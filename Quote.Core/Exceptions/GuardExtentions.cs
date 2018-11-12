using Quote.Core.Exceptions;
using Quote.Core.Entities.Client;

namespace Ardalis.GuardClauses
{
    public static class ClientGuard
    {
        public static void NullBasket(this IGuardClause guardClause, int clientId, Client client)
        {
            if (client == null)
                throw new ClientNotFoundException(clientId);
        }
    }
}
