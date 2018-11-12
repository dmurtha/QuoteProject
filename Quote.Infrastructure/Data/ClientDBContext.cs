using Microsoft.EntityFrameworkCore;
using Quote.Core.Entities.Client;
using Quote.Common.Extensions;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Quote.Infrastructure.Data
{
    public class ClientDBContext : DbContext
    {

        public ClientDBContext(DbContextOptions<ClientDBContext> opts) : base(opts) { }



        //private void ConfigureClient(EntityTypeBuilder<Client> builder)
        //{
        //    var navigation = builder.Metadata.FindNavigation(nameof(Client.ClientAddresses));
        //    navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        //    builder.OwnsOne(o => o.ClientAddress);
        //}
        //private void ConfigureClientAddress(EntityTypeBuilder<ClientAddress> builder)
        //{
        //    var navigation = builder.Metadata.FindNavigation(nameof(ClientAddress.ClientAddressTypes));
        //    navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        //    builder.OwnsOne(cl => cl.ClientAddressTypes);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


         //   modelBuilder.Entity<Client>(ConfigureClient);
         //   modelBuilder.Entity<ClientAddress>(ConfigureClientAddress);


            modelBuilder.Entity<Client>()
              .HasData(new
              {
                  Id = 1,
                  ClientName = "Texas Location Travels",
                  ClientType = ClientTypes.Location,
                  ClientGuid = Guid.NewGuid()
              },
              new
              {
                  Id = 2,
                  ClientName = "Texas Agency Travels",
                  ClientType = ClientTypes.Agency,
                  ClientGuid = Guid.NewGuid()
              },
              new
              {
                  Id = 3,
                  ClientName = "Texas Master Agency Travels",
                  ClientType = ClientTypes.MasterAgency,
                  ClientGuid = Guid.NewGuid()
              },
              new
              {
                  Id = 4,
                  ClientName = "Kansas Location Travels",
                  ClientType = ClientTypes.Location,
                  ClientGuid = Guid.NewGuid()
              },
              new
              {
                  Id = 5,
                  ClientName = "Kansas Agency Travels",
                  ClientType = ClientTypes.Agency,
                  ClientGuid = Guid.NewGuid()
              }, new
              {
                  Id = 6,
                  ClientName = "Kansas Master Agency Travels",
                  ClientType = ClientTypes.MasterAgency,
                  ClientGuid = Guid.NewGuid()
              }, new
              {
                  Id = 7,
                  ClientName = "Colorado Location Travels",
                  ClientType = ClientTypes.Location,
                  ClientGuid = Guid.NewGuid()
              }, new
              {
                  Id = 8,
                  ClientName = "Colorado Agency Travels",
                  ClientType = ClientTypes.Agency,
                  ClientGuid = Guid.NewGuid()
              }, new
              {
                  Id = 9,
                  ClientName = "Colorado Master Agency Travels",
                  ClientType = ClientTypes.MasterAgency,
                  ClientGuid = Guid.NewGuid()
              }
              );


            modelBuilder.Entity<ClientAddress>()
              // Anonymous Type
              .HasData(new
              {
                  Id = 1,
                  AddressName = "Texas Address",
                  AddressStreet = "123 Texas Lane",
                  Apt = "1",
                  ZipCode = "12345",
                  State = "TX",
                  City = "Houston",
                  Country = "USA",
                  ClientId = 1
              }, new
              {
                  Id = 2,
                  AddressName = "Texas Address",
                  AddressStreet = "123 Texas Lane",
                  Apt = "1",
                  ZipCode = "12345",
                  State = "TX",
                  City = "Houston",
                  Country = "USA",
                  ClientId = 2
              }, new
              {
                  Id = 3,
                  AddressName = "Texas Address",
                  AddressStreet = "123 Texas Lane",
                  Apt = "1",
                  ZipCode = "12345",
                  State = "TX",
                  City = "Houston",
                  Country = "USA",
                  ClientId = 3
              }, new
              {
                  Id = 4,
                  AddressName = "Kansas Address",
                  AddressStreet = "123 Kansas Lane",
                  Apt = "1",
                  ZipCode = "12345",
                  State = "KS",
                  City = "Derby",
                  Country = "USA",
                  ClientId = 4
              }, new
              {
                  Id = 5,
                  AddressName = "Kansas Address",
                  AddressStreet = "123 Kansas Lane",
                  Apt = "1",
                  ZipCode = "12345",
                  State = "KS",
                  City = "Wichita",
                  Country = "USA",
                  ClientId = 5
              }, new
              {
                  Id = 6,
                  AddressName = "Kansas Address",
                  AddressStreet = "123 Kansas Lane",
                  Apt = "1",
                  ZipCode = "12345",
                  State = "KS",
                  City = "Wichita",
                  Country = "USA",
                  ClientId = 6
              }, new
              {
                  Id = 7,
                  AddressName = "Colorado Address",
                  AddressStreet = "123 Colorado Lane",
                  Apt = "1",
                  ZipCode = "12345",
                  State = "TX",
                  City = "Houston",
                  Country = "USA",
                  ClientId = 7
              }, new
              {
                  Id = 8,
                  AddressName = "Colorado Address",
                  AddressStreet = "123 Colorado Lane",
                  Apt = "1",
                  ZipCode = "12345",
                  State = "CO",
                  City = "Denver",
                  Country = "USA",
                  ClientId = 8
              }, new
              {
                  Id = 9,
                  AddressName = "Colorado Address",
                  AddressStreet = "123 Colorado Lane",
                  Apt = "1",
                  ZipCode = "12345",
                  State = "CO",
                  City = "Denver",
                  Country = "USA",
                  ClientId = 9
              });
       modelBuilder.Entity<ClientAddressLevel>()
      // Anonymous Type
              .HasData(new
              {
                Id = 1,
                ClientAddressId = 1,
                  ClientAddressType = Common.Extensions.AddressTypes.AdditionalOffice
              }, new
              {
                  Id = 2,
                  ClientAddressId = 1,
                  ClientAddressType = Common.Extensions.AddressTypes.HeadOffice
                  
              }, new
              {
                  Id = 3,
                  ClientAddressId = 2,
                  ClientAddressType = Common.Extensions.AddressTypes.AdditionalOffice
              }, new
              {
                  Id = 4,
                  ClientAddressId = 2,
                  ClientAddressType = Common.Extensions.AddressTypes.HeadOffice
              }, new
              {
                  Id = 5,
                  ClientAddressId = 3,
                  ClientAddressType = Common.Extensions.AddressTypes.AdditionalOffice
              },new
              {
                  Id = 6,
                  ClientAddressId = 3,
                  ClientAddressType = Common.Extensions.AddressTypes.HeadOffice
              }, new
              {
                  Id = 7,
                  ClientAddressId = 4,
                  ClientAddressType = Common.Extensions.AddressTypes.AdditionalOffice
              }, new
              {
                  Id = 8,
                  ClientAddressId = 4,
                  ClientAddressType = Common.Extensions.AddressTypes.HeadOffice
              }, new
              {
                  Id = 9,
                  ClientAddressId = 5,
                  ClientAddressType = Common.Extensions.AddressTypes.AdditionalOffice
              }, new
              {
                  Id = 10,
                  ClientAddressId = 5,
                  ClientAddressType = Common.Extensions.AddressTypes.HeadOffice
              }, new
              {
                  Id = 11,
                  ClientAddressId = 6,
                  ClientAddressType = Common.Extensions.AddressTypes.AdditionalOffice
              }, new
              {
                  Id = 12,
                  ClientAddressId = 6,
                  ClientAddressType = Common.Extensions.AddressTypes.HeadOffice
              }, new
              {
                  Id = 13,
                  ClientAddressId = 7,
                  ClientAddressType = Common.Extensions.AddressTypes.AdditionalOffice
              }, new
              {
                  Id = 14,
                  ClientAddressId = 7,
                  ClientAddressType = Common.Extensions.AddressTypes.HeadOffice
              }, new
              {
                  Id = 15,
                  ClientAddressId = 8,
                  ClientAddressType = Common.Extensions.AddressTypes.AdditionalOffice
              }, new
              {
                  Id = 16,
                  ClientAddressId = 8,
                  ClientAddressType = Common.Extensions.AddressTypes.HeadOffice
              }, new
              {
                  Id = 17,
                  ClientAddressId = 9,
                  ClientAddressType = Common.Extensions.AddressTypes.AdditionalOffice
              }, new
              {
                  Id = 18,
                  ClientAddressId = 8,
                  ClientAddressType = Common.Extensions.AddressTypes.HeadOffice
              });


}

        //*Client
                //*ClientAddress
                     //*Address Type
                //ClientClientPhone
                //ClientParent
                //ClientContact
                        //Contact Type
                        //ClientContactPhone




        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }
        public DbSet<ClientClientPhone> ClientClientPhones { get; set; }
        public DbSet<ClientContact> ClientContacts { get; set; }
        public DbSet<ClientContactPhone> ClientContactPhones { get; set; }
        public DbSet<ClientContactLevel> ClientContactTypes { get; set; }
        public DbSet<ClientParent> ClientParents { get; set; }
        public DbSet<ClientAddressLevel> ClientAddressLevels { get; set; }

    }
}
