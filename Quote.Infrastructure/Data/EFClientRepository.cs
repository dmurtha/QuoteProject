using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quote.Core.Entities;
using Quote.Core.Interfaces;

namespace Quote.Infrastructure.Data
{
    public class EFClientRepository<T> : IAsyncClient<T>, IClient<T> where T : BaseEntity
    {
        private ClientDBContext _context;

        public EFClientRepository(ClientDBContext cnt) => _context = cnt;

        public IEnumerable<T> ListAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria)
                            .AsEnumerable();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetById(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .FirstOrDefault(spec.Criteria);
        }

        public async Task<T> GetByIdAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .FirstOrDefaultAsync(spec.Criteria);
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }


        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public T Attach(T entity)
        {
            _context.Set<T>().Attach(entity);

            return entity;
        }

        public List<T> AttachRange(List<T> entity)
        {
            _context.Set<T>().AttachRange(entity);

            return entity;
        }

        public void SetDelete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public async void DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async void DeleteRangeAsync(List<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        public void DeleteRange(List<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
            _context.SaveChanges();
        }
        //public IEnumerable<Client> Clients => context.Clients;

        //public List<ClientDisplayViewModel> GetClients()
        //{
        //   List<Client> clients = new List<Client>();
        //    clients = context.Clients
        //        .AsNoTracking()
        //        .Select(c => new Client {ClientName = c.ClientName, ClientType = c.ClientType})
        //        .ToList();

        //    if (clients != null)
        //    {
        //        List<ClientDisplayViewModel> clientsDisplay = new List<ClientDisplayViewModel>();
        //        foreach (Client c in clients)
        //        {
        //            clientsDisplay.Add(new ClientDisplayViewModel(c.ClientName, c.ClientType));
        //        }
        //        return clientsDisplay;
        //    }
        //    return null;
        //}

        //public Client GetClient(int id) => context.Clients.Where(s => s.Id == id).FirstOrDefault();

        //public ClientAddress GetClientAddress(int id) => context.ClientAddresses.Where(s => s.ClientId == id).FirstOrDefault();

        //public IEnumerable<ClientClientPhone> GetClientClientPhones(int id) => context.ClientClientPhones.Where(s => s.ClientId == id);

        //public IEnumerable<ClientContactLevel> GetClientContactTypes(int id) => context.ClientContactTypes.Where(s => s.ClientContactId == id);

        //public IEnumerable<ClientAddressLevel> GetClientAddressTypes(int id) => context.ClientAddressTypes.Where(s => s.ClientAddressId == id);

        //public IEnumerable<ClientContact> GetClientContacts(int id) => context.ClientContacts.Where(s => s.ClientId == id);

        //public IEnumerable<ClientContactPhone> GetClientContactPhones(int id) => context.ClientContactPhones.Where(s => s.ClientContactId == id);

        //public ClientParent GetClientParent(int id) => context.ClientParents.Where(s => s.Id == id).FirstOrDefault();

        //public void AddClient(Client client)
        //{
        //    context.Clients.Add(client);
        //    context.SaveChanges();
        //}

        //public void DeleteClient(int id)
        //{
        //    context.Clients.Remove(new Client { Id = id });
        //    context.SaveChanges();
        //}

        //public void UpdateClient(Client client, Client originalClient = null)
        //{
        //    if(originalClient == null)
        //    {
        //        originalClient = context.Clients.Find(client.Id);
        //    } else
        //    {
        //        context.Clients.Attach(client);
        //    }

        //    originalClient.ClientName = client.ClientName;
        //    originalClient.ClientType = client.ClientType;
        //    context.SaveChanges();    
        //    }

    }
}
