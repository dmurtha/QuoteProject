using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quote.Infrastructure.Migrations
{
    public partial class ContextStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    ClientType = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    ClientGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AddressName = table.Column<string>(nullable: true),
                    AddressStreet = table.Column<string>(nullable: true),
                    Apt = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientAddresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ClientFistName = table.Column<string>(nullable: true),
                    ClientLastName = table.Column<string>(nullable: true),
                    ClientTitle = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientContacts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientParents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientParents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientParents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddressLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ClientAddressType = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    ClientAddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddressLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientAddressLevels_ClientAddresses_ClientAddressId",
                        column: x => x.ClientAddressId,
                        principalTable: "ClientAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientClientPhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    PhoneType = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    ClientContactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClientPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientClientPhones_ClientContacts_ClientContactId",
                        column: x => x.ClientContactId,
                        principalTable: "ClientContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientClientPhones_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientContactPhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    PhoneType = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    ClientContactId = table.Column<long>(nullable: false),
                    ClientContactId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContactPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientContactPhones_ClientContacts_ClientContactId1",
                        column: x => x.ClientContactId1,
                        principalTable: "ClientContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientContactTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ClientContactType = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    ClientContactId = table.Column<long>(nullable: false),
                    ClientContactId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContactTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientContactTypes_ClientContacts_ClientContactId1",
                        column: x => x.ClientContactId1,
                        principalTable: "ClientContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientGuid", "ClientName", "ClientType", "Timestamp" },
                values: new object[,]
                {
                    { 1, new Guid("bd0faefa-70c4-4e56-a320-179d5f44430b"), "Texas Location Travels", "Location", null },
                    { 2, new Guid("f218dff4-dbca-4599-a0c8-3d1ad62b0f4a"), "Texas Agency Travels", "Agency", null },
                    { 3, new Guid("8cfa11fb-258d-4074-a5ca-89ab738ab324"), "Texas Master Agency Travels", "MasterAgency", null },
                    { 4, new Guid("2e9b2059-2a5e-494d-93f1-82c81c645dde"), "Kansas Location Travels", "Location", null },
                    { 5, new Guid("342ac1e0-13a1-4a38-a80e-11c911abfb7a"), "Kansas Agency Travels", "Agency", null },
                    { 6, new Guid("5d9f2d73-6f9b-48df-8930-98bc59c89f8b"), "Kansas Master Agency Travels", "MasterAgency", null },
                    { 7, new Guid("b9546750-d21b-43e3-a10c-3461225a56e0"), "Colorado Location Travels", "Location", null },
                    { 8, new Guid("745a4c13-6892-4df6-9324-a2ac8ecd54fa"), "Colorado Agency Travels", "Agency", null },
                    { 9, new Guid("5440a77a-2830-4255-bafd-a03af7ff6332"), "Colorado Master Agency Travels", "MasterAgency", null }
                });

            migrationBuilder.InsertData(
                table: "ClientAddresses",
                columns: new[] { "Id", "AddressName", "AddressStreet", "Apt", "City", "ClientId", "Country", "State", "Timestamp", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Texas Address", "123 Texas Lane", "1", "Houston", 1, "USA", "TX", null, "12345" },
                    { 2, "Texas Address", "123 Texas Lane", "1", "Houston", 2, "USA", "TX", null, "12345" },
                    { 3, "Texas Address", "123 Texas Lane", "1", "Houston", 3, "USA", "TX", null, "12345" },
                    { 4, "Kansas Address", "123 Kansas Lane", "1", "Derby", 4, "USA", "KS", null, "12345" },
                    { 5, "Kansas Address", "123 Kansas Lane", "1", "Wichita", 5, "USA", "KS", null, "12345" },
                    { 6, "Kansas Address", "123 Kansas Lane", "1", "Wichita", 6, "USA", "KS", null, "12345" },
                    { 7, "Colorado Address", "123 Colorado Lane", "1", "Houston", 7, "USA", "TX", null, "12345" },
                    { 8, "Colorado Address", "123 Colorado Lane", "1", "Denver", 8, "USA", "CO", null, "12345" },
                    { 9, "Colorado Address", "123 Colorado Lane", "1", "Denver", 9, "USA", "CO", null, "12345" }
                });

            migrationBuilder.InsertData(
                table: "ClientAddressLevels",
                columns: new[] { "Id", "ClientAddressId", "ClientAddressType", "Timestamp" },
                values: new object[,]
                {
                    { 1, 1, "AdditionalOffice", null },
                    { 16, 8, "HeadOffice", null },
                    { 15, 8, "AdditionalOffice", null },
                    { 14, 7, "HeadOffice", null },
                    { 13, 7, "AdditionalOffice", null },
                    { 12, 6, "HeadOffice", null },
                    { 11, 6, "AdditionalOffice", null },
                    { 10, 5, "HeadOffice", null },
                    { 9, 5, "AdditionalOffice", null },
                    { 8, 4, "HeadOffice", null },
                    { 7, 4, "AdditionalOffice", null },
                    { 6, 3, "HeadOffice", null },
                    { 5, 3, "AdditionalOffice", null },
                    { 4, 2, "HeadOffice", null },
                    { 3, 2, "AdditionalOffice", null },
                    { 2, 1, "HeadOffice", null },
                    { 18, 8, "HeadOffice", null },
                    { 17, 9, "AdditionalOffice", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddresses_ClientId",
                table: "ClientAddresses",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddressLevels_ClientAddressId",
                table: "ClientAddressLevels",
                column: "ClientAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientClientPhones_ClientContactId",
                table: "ClientClientPhones",
                column: "ClientContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientClientPhones_ClientId",
                table: "ClientClientPhones",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContactPhones_ClientContactId1",
                table: "ClientContactPhones",
                column: "ClientContactId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_ClientId",
                table: "ClientContacts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContactTypes_ClientContactId1",
                table: "ClientContactTypes",
                column: "ClientContactId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClientParents_ClientId",
                table: "ClientParents",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientAddressLevels");

            migrationBuilder.DropTable(
                name: "ClientClientPhones");

            migrationBuilder.DropTable(
                name: "ClientContactPhones");

            migrationBuilder.DropTable(
                name: "ClientContactTypes");

            migrationBuilder.DropTable(
                name: "ClientParents");

            migrationBuilder.DropTable(
                name: "ClientAddresses");

            migrationBuilder.DropTable(
                name: "ClientContacts");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
