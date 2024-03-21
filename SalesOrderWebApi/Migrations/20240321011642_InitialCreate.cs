using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesOrderWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketingAreas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpareparts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COGS = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpareparts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketingAreaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_MarketingAreas_MarketingAreaId",
                        column: x => x.MarketingAreaId,
                        principalTable: "MarketingAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductSparepartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductSpareparts_ProductSparepartId",
                        column: x => x.ProductSparepartId,
                        principalTable: "ProductSpareparts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CustomerName", "CustomerNo", "CustomerType", "Phone" },
                values: new object[,]
                {
                    { "306e14c7-1ffe-415e-ba04-862ab009ca56", "Depok", "Cust Name E", "CS5", "Mr", "+15" },
                    { "64eb1e27-71eb-4e99-ba25-4d4cae11a8c9", "Surabaya", "Cust Name C", "CS3", "Company", "+13" },
                    { "8493afbc-45ce-486b-b3d4-5ca0159d40ad", "Bogor", "Cust Name B", "CS2", "Mr", "+12" },
                    { "91555283-d1b8-4e64-8136-25405bb338a2", "Jakarta", "Cust Name A", "CS1", "Mrs", "+11" },
                    { "bcbbb51c-01d6-4e5d-a4e7-244ee62c3ecd", "Semarang", "Cust Name D", "CS4", "Mrs", "+14" }
                });

            migrationBuilder.InsertData(
                table: "MarketingAreas",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { "16683c71-b113-474f-a980-59652c0039bd", "A003", "Area Jawa, Bali dan Indonesia Timur" },
                    { "33820513-45d8-4dba-a841-13b2f341a569", "A001", "Area Sumatera" },
                    { "cbea3799-18f4-4672-bbc9-307b9943ce55", "A002", "Area Jabodetabek" }
                });

            migrationBuilder.InsertData(
                table: "ProductSpareparts",
                columns: new[] { "Id", "Brand", "COGS", "Code", "Description", "Type", "UOM" },
                values: new object[,]
                {
                    { "3e0ee962-819b-45b6-aa18-035399f21a6b", "Brand3", 9000m, "P00003", "Bolt", "SPA", "Box" },
                    { "44e42048-45a2-4077-ba8a-e1873c85ac38", "Brand4", 1200000m, "P00004", "Shock Breaker", "SPA", "PCS" },
                    { "9a40d0e1-7bf7-4cf0-9199-f5858a44d9fb", "Brand1", 500m, "P00001", "Pencil", "PRO", "PCS" },
                    { "aed2eec2-0385-4b7b-8611-dae8c420bea8", "Brand5", 700000m, "P00005", "Tire", "SPA", "PCS" },
                    { "c28f8d1c-ddcc-4684-8f2c-5ee10b6c714c", "Brand2", 50000m, "P00002", "Table", "PRO", "PCS" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Code", "Description", "MarketingAreaId", "Phone" },
                values: new object[,]
                {
                    { "0b6f44f0-2701-4df1-82d1-9d66a7384fdd", "Jl Sudirman", "S00004", "Surabaya", "16683c71-b113-474f-a980-59652c0039bd", "123456" },
                    { "1dc445e8-2c81-4ba1-83ee-e08f47e48a77", "Jl Semeru", "S00001", "Medan", "33820513-45d8-4dba-a841-13b2f341a569", "123456" },
                    { "64c632f2-2eec-4e26-8ee9-4593c91cb8c2", "Jl Dewa", "S00005", "Bali", "16683c71-b113-474f-a980-59652c0039bd", "123456" },
                    { "8b649e89-48b7-4d06-9d4d-612d4fbb0093", "Jl Sudirman", "S00003", "Jakarta", "cbea3799-18f4-4672-bbc9-307b9943ce55", "123456" },
                    { "c0c23ef3-3c81-4362-b862-43b0344b51c2", "Jl Gajah", "S00002", "Palembang", "33820513-45d8-4dba-a841-13b2f341a569", "123456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductSparepartId",
                table: "OrderItems",
                column: "ProductSparepartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreId",
                table: "Orders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_MarketingAreaId",
                table: "Stores",
                column: "MarketingAreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductSpareparts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "MarketingAreas");
        }
    }
}
