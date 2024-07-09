using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressToShips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressToShips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalQuantityVoucher = table.Column<int>(type: "int", nullable: true),
                    UsedQuanity = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    PriceSold = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantitySold = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPercent = table.Column<float>(type: "real", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChildCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ParentCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    ConfirmToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipCompanyId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shippers_ShipCompanies_ShipCompanyId",
                        column: x => x.ShipCompanyId,
                        principalTable: "ShipCompanies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercent = table.Column<double>(type: "float", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_ChildCategories_ChildCategoryId",
                        column: x => x.ChildCategoryId,
                        principalTable: "ChildCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AddressUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AddressToShipId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressUsers_AddressToShips_AddressToShipId",
                        column: x => x.AddressToShipId,
                        principalTable: "AddressToShips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AddressUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikeQuantity = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ShipperId = table.Column<int>(type: "int", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreightCost = table.Column<double>(type: "float", nullable: true),
                    IsConfirm = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    StatusOfPayment = table.Column<int>(type: "int", nullable: true),
                    AddressToShipId = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AddressToShips_AddressToShipId",
                        column: x => x.AddressToShipId,
                        principalTable: "AddressToShips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Shippers_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shippers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductMaterials_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VoucherUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    TimeUsage = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherUsages_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VoucherUsages_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReportOfUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    ReportTypeId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportOfUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportOfUsers_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportOfUsers_ReportTypes_ReportTypeId",
                        column: x => x.ReportTypeId,
                        principalTable: "ReportTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, false, null, null, "VESTA" },
                    { 2, null, null, null, null, false, null, null, "MEDOPHARM" },
                    { 3, null, null, null, null, false, null, null, "Công ty TNHH Abbott Healthcare Việt Nam" },
                    { 4, null, null, null, null, false, null, null, "TIPHARCO" },
                    { 5, null, null, null, null, false, null, null, "STADA" },
                    { 6, null, null, null, null, false, null, null, "CÔNG TY TNHH DƯỢC THẢO HOÀNG THÀNH" },
                    { 7, null, null, null, null, false, null, null, "CÔNG TY CỔ PHẦN KOREA UNITED PHARM. INT’L" },
                    { 8, null, null, null, null, false, null, null, "DANAPHA" },
                    { 9, null, null, null, null, false, null, null, "CÔNG TY CỔ PHẦN DƯỢC PHẨM GLOMED VIỆT NAM" },
                    { 10, null, null, null, null, false, null, null, "S.C. ANTIBIOTICE S.A" },
                    { 11, null, null, null, null, false, null, null, "US PHARMA" },
                    { 12, null, null, null, null, false, null, null, "CÔNG TY TNHH BRV HEALTHCARE" },
                    { 13, null, null, null, null, false, null, null, "CÔNG TY CP DƯỢC NATURE VIỆT NAM" },
                    { 14, null, null, null, null, false, null, null, "STELLA" }
                });

            migrationBuilder.InsertData(
                table: "ParentCategories",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, false, null, null, "Thực phẩm chức năng" },
                    { 2, null, null, null, null, false, null, null, "Dược mỹ phẩm" },
                    { 3, null, null, null, null, false, null, null, "Chăm sóc cá nhân" },
                    { 4, null, null, null, null, false, null, null, "Thuốc" },
                    { 5, null, null, null, null, false, null, null, "Thiết bị y tế" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Customer", false, null, null, "Customer" },
                    { 2, null, null, null, null, "Admin", false, null, null, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "ChildCategories",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, false, null, null, "Thuốc kháng sinh, kháng nấm", 4 },
                    { 2, null, null, null, null, false, null, null, "Thuốc điều trị ung thư", 4 },
                    { 3, null, null, null, null, false, null, null, "Thuốc tim mạch và máu", 4 },
                    { 4, null, null, null, null, false, null, null, "Thuốc thần kinh", 4 },
                    { 5, null, null, null, null, false, null, null, "Thuốc tiêu hóa và gan mật", 4 },
                    { 6, null, null, null, null, false, null, null, "Bổ sung Canxi và vitamin D", 1 },
                    { 7, null, null, null, null, false, null, null, "Vitamin tổng hợp", 1 },
                    { 8, null, null, null, null, false, null, null, "Dầu cá, Omega 3, DHA", 1 },
                    { 9, null, null, null, null, false, null, null, "Vitamind C các loại", 1 },
                    { 10, null, null, null, null, false, null, null, "Bổ sung sắt và Axit Folic", 1 },
                    { 11, null, null, null, null, false, null, null, "Sinh lý nam", 1 },
                    { 12, null, null, null, null, false, null, null, "Sức khỏe tình dục", 1 },
                    { 13, null, null, null, null, false, null, null, "Cân bằng nội tiết tố", 1 },
                    { 14, null, null, null, null, false, null, null, "Sinh lý nữ", 1 },
                    { 15, null, null, null, null, false, null, null, "Hỗ trợ mãn kinh", 1 },
                    { 16, null, null, null, null, false, null, null, "Dụng cụ vệ sinh mũi", 5 },
                    { 17, null, null, null, null, false, null, null, "Kim các loại", 5 },
                    { 18, null, null, null, null, false, null, null, "Máy massage", 5 },
                    { 19, null, null, null, null, false, null, null, "Túi chườm", 5 },
                    { 20, null, null, null, null, false, null, null, "Vớ ngăn tĩnh mạch", 5 },
                    { 21, null, null, null, null, false, null, null, "Găng tay", 5 },
                    { 22, null, null, null, null, false, null, null, "Đai lưng", 5 },
                    { 23, null, null, null, null, false, null, null, "Dụng cụ vệ sinh tai", 5 },
                    { 24, null, null, null, null, false, null, null, "Đai nẹp", 5 },
                    { 25, null, null, null, null, false, null, null, "Bao cao su", 3 },
                    { 26, null, null, null, null, false, null, null, "Gel bôi trơn", 3 },
                    { 27, null, null, null, null, false, null, null, "Sữa rửa mặt", 2 },
                    { 28, null, null, null, null, false, null, null, "Kem chống nắng", 2 },
                    { 29, null, null, null, null, false, null, null, "Dưỡng da mặt", 2 },
                    { 30, null, null, null, null, false, null, null, "Mặt nạ", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "Country", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "DiscountPercent", "IsDeleted", "ModificationBy", "ModificationDate", "Name", "PriceSold", "Quantity", "QuantitySold", "Status", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 5, "Việt Nam", null, null, null, null, "Fluconazole 150mg là sản phẩm của Công ty TNHH Stada Việt Nam có thành phần chính là Fluconazole có tác dụng điều trị các bệnh nấm Candida tại chỗ và toàn thân, các bệnh nấm do các chủng vi khuẩn khác và dự phòng nhiễm nấm Candida ở bệnh nhân ghép tủy xương đang được hóa trị liệu gây độc tế bào hoặc xạ trị.", 0.1f, null, null, null, "Thuốc Fluconazole Stada 150mg", 25.0, 100, 0, null, 27.5 },
                    { 2, 6, "Việt Nam", null, null, null, null, "Hoạt Huyết Trường Phúc là sản phẩm của Công ty TNHH Dược Thảo Hoàng Thành có thành phần chính là cao đặc hỗn hợp các dược liệu đương quy, ích mẫu, ngưu tất, thục địa, xích thược, xuyên khung có công dụng điều trị các chứng huyết hư, ứ trệ. Phòng ngừa và điều trị thiểu năng tuần hoàn não (mệt mỏi, đau đầu, chóng mặt, mất thăng bằng, hoa mắt, mất ngủ, suy giảm trí nhớ), thiểu năng tuần hoàn ngoại vi (đau mỏi vai gáy, tê cứng cổ, đau cách hồi, đau cơ, tê bì chân tay), phòng ngừa và hỗ trợ điều trị xơ vữa động mạch, nghẽn mạch, tai biến mạch máo não.", 0.1f, null, null, null, "Thuốc Hoạt Huyết Trường Phúc", 95.0, 100, 0, null, 104.5 },
                    { 3, 7, "Việt Nam", null, null, null, null, "Ginkokup 40 là sản phẩm thuốc của Công ty cổ phần Korea United Pharm. Int' L. - Singapore với thành phần hoạt chất là cao chiết lá bạch quả được chỉ định trong điều trị bệnh sa sút trí tuệ, kể cả bệnh Alzheimer; điều trị các rối loạn mạch máu não, các di chứng sau các tai biến mạch máu não và chấn thương sọ não, hội chứng về não cũng như bị nhức đầu, suy giảm trí nhớ, rối loạn tập trung, suy nhược, chóng mặt; điều trị các bệnh rối loạn tuần hoàn ngoại biên, cải thiện hội chứng Raynaud và điều trị các triệu chứng của bệnh đau cách hồi; điều trị ù tai do mạch máu hoặc do thoái hóa.", 0.1f, null, null, null, "Thuốc Ginkokup 40 Korea United", 150.0, 100, 0, null, 165.0 },
                    { 4, 8, "Việt Nam", null, null, null, null, "Thuốc Dacolfort được sản xuất bởi Dược Danapha, có thành phần chính là Diosminn và Hesperidin, được chỉ định để điều trị những triệu chứng có liên quan đến suy tĩnh mạch, mạch bạch huyết (nặng chân, đau, chân khó chịu vào buổi sáng). Điều trị các dấu hiệu chức năng có liên quan tới cơn trĩ cấp.", 0.1f, null, null, null, "Thuốc Dacolfort Danapha", 78.0, 100, 0, null, 85.799999999999997 },
                    { 5, 9, "Việt Nam", null, null, null, null, "Thuốc Henex là sản phẩm của Công ty Cổ phần Dược phẩm Glomed (Abbott) có thành phần chính là phân đoạn flavonoid. Thuốc dùng điều trị các triệu chứng và dấu hiệu của suy tĩnh mạch – mạch bạch huyết vô căn mạn tính ở chi dưới như nặng ở chân, đau chân, phù chân, chuột rút về đêm và chồn chân. Điều trị các triệu chứng của cơn trĩ cấp và bệnh trĩ mạn tính.", 0.1f, null, null, null, "Thuốc Henex 500mg Abbott", 220.0, 100, 0, null, 242.0 },
                    { 6, 10, "Romania", null, null, null, null, "Thuốc Catavastatin 10 mg của S.C. ANTIBIOTICE S.A, thuốc có thành phần chính là Rosuvastatin. Đây là thuốc được dùng để điều trị tăng cholesterol máu nguyên phát, rối loạn lipid máu hỗn hợp, điều trị tăng cholesterol máu gia đình kiểu đồng hợp tử.", 0.1f, null, null, null, "Thuốc Catavastatin 10mg S.C Antibiotice", 300.0, 100, 0, null, 330.0 },
                    { 7, 11, "Việt Nam", null, null, null, null, "Valsartan-MV 80mg được sản xuất bởi Công ty TNHH US Pharma USA, thành phần chính là valsartan, được dùng để điều trị bệnh tăng huyết áp và suy tim ở người lớn và trẻ em trên 6 tuổi. Ngoài ra, thuốc cũng được dùng để tăng cơ hội sống sót kéo dài hơn sau cơn nhồi máu cơ tim.", 0.1f, null, null, null, "Thuốc Valsartan-MV 80mg USP", 120.0, 100, 0, null, 132.0 },
                    { 8, 12, "Việt Nam", null, null, null, null, "Thuốc Carhurol 10 là sản phẩm của Công ty cổ phần BV Pharma. Thuốc có thành phần chính là Rosuvastatin. Đây là thuốc dùng để điều trị tăng cholesterol máu ở người lớn, thanh thiếu niên, trẻ em từ 6 tuổi trở lên và phòng ngừa các biến cố tim mạch.", 0.1f, null, null, null, "Thuốc Carhurol 10 BRV", 250.0, 100, 0, null, 275.0 },
                    { 9, 13, "Việt Nam", null, null, null, null, "Npluvico được sản xuất bởi Công ty Cổ phần Dược Nature Việt Nam. Thuốc có thành phần chính là cao khô lá bạch quả, cao khô rễ đinh lăng.\r\n\r\nNpluvico dùng để điều trị suy tuần hoàn não, rối loạn tuần hoàn ngoại biên, rối loạn thần kinh cảm giác, rối loạn thị giác (bệnh võng mạc), bệnh về tai mũi họng (chóng mặt, ù tai, giảm thính lực), di chứng tai biến mạch máu não và chấn thương sọ não. Phòng ngừa và làm chậm quá trình tiến triển của bệnh Alzheimer ở người lớn tuổi.", 0.1f, null, null, null, "Thuốc Npluvico Nature", 168.0, 100, 0, null, 184.80000000000001 },
                    { 10, 13, "Việt Nam", null, null, null, null, "Scanneuron được sản xuất bởi công ty Stella, thành phần chính là Thiamin nitrat (Vitamin B1), Pyridoxin hydroclorid (vitamin B6), Cyanocobalamin (vitamin B12), được chỉ định để điều trị hỗ trợ các rối loạn về hệ thần kinh như đau dây thần kinh, viêm dây thần kinh ngoại biên, viêm dây thần kinh mắt, viêm dây thần kinh do tiểu đường và do rượu, viêm đa dây thần kinh, dị cảm, đau thần kinh tọa và co giật do tăng tính dễ kích thích của hệ thần kinh trung ương.", 0.1f, null, null, null, "Thuốc Scanneuron Stella", 125.0, 100, 0, null, 137.5 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "ImageLink", "IsDeleted", "ModificationBy", "ModificationDate", "ProductId", "Thumbnail" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_4732_624e_large_38eebb47c6.jpg", false, null, null, 1, true },
                    { 2, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_5259_624e_large_672d2b5a9e.jpg", false, null, null, 1, false },
                    { 3, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_7354_624e_large_01a868ca04.jpg", false, null, null, 1, false },
                    { 4, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_7063_624e_large_830492cc36.jpg", false, null, null, 1, false },
                    { 5, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_2072_624e_large_7c79ce80d5.jpg", false, null, null, 1, false },
                    { 6, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_3524_624e_large_68760098c9.jpg", false, null, null, 1, false },
                    { 7, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_3439_6293_large_fce5c74dce.jpg", false, null, null, 2, true },
                    { 8, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_1339_6293_large_2fbeef8a80.jpg", false, null, null, 2, false },
                    { 9, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_9001_6293_large_d466889fe8.jpg", false, null, null, 2, false },
                    { 10, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_5493_6293_large_eaef9efed8.jpg", false, null, null, 2, false },
                    { 11, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_5613_6293_large_b6207da4c9.jpg", false, null, null, 2, false },
                    { 12, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_5302_6293_large_cb9d8bb7d0.jpg", false, null, null, 2, false },
                    { 13, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_1754_61c9_large_1c441194d7.jpg", false, null, null, 3, true },
                    { 14, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_4870_61ca_large_d695e0e56c.jpg", false, null, null, 3, false },
                    { 15, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_7727_61c9_large_0288abb0c6.jpg", false, null, null, 3, false },
                    { 16, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_3531_61c9_large_239e93283d.jpg", false, null, null, 3, false },
                    { 17, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_7982_61c9_large_d93fb7b527.jpg", false, null, null, 3, false },
                    { 18, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_9403_61c9_large_62caccad63.jpg", false, null, null, 3, false },
                    { 19, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_4751_61c9_large_8104fe3818.jpg", false, null, null, 3, false },
                    { 20, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00029275_dacolfort_500mg_danapha_3x10_6954_6062_large_fdad157540.jpg", false, null, null, 4, true },
                    { 21, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00029275_dacolfort_500mg_danapha_3x10_9199_6062_large_76a7c96d6f.jpg", false, null, null, 4, false },
                    { 22, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00029275_dacolfort_500mg_danapha_3x10_4671_6062_large_a94f37f148.jpg", false, null, null, 4, false },
                    { 23, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00029275_dacolfort_500mg_danapha_3x10_9994_6062_large_aaf9f67a9d.jpg", false, null, null, 4, false },
                    { 24, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_09967_d0eba34d24.jpg", false, null, null, 5, true },
                    { 25, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_09971_b413c0cf14.jpg", false, null, null, 5, false },
                    { 26, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_09973_817ea771bb.jpg", false, null, null, 5, false },
                    { 27, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00172_a49dadfd55.jpg", false, null, null, 6, true },
                    { 28, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00175_8f116c3675.jpg", false, null, null, 6, false },
                    { 29, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00178_b91485146e.jpg", false, null, null, 6, false },
                    { 30, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00179_b1dc3be312.jpg", false, null, null, 6, false },
                    { 31, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03394_e628d9caee.jpg", false, null, null, 7, true },
                    { 32, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03398_copy_12c67a69b8.jpg", false, null, null, 7, false },
                    { 33, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03397_842e04f439.jpg", false, null, null, 7, false },
                    { 34, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03400_ec50318d8e.jpg", false, null, null, 7, false },
                    { 35, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03401_b375b86c28.jpg", false, null, null, 7, false },
                    { 36, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03512_efbea39e45.jpg", false, null, null, 8, true },
                    { 37, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03515_38d3012027.jpg", false, null, null, 8, false },
                    { 38, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03520_06e66bad9f.jpg", false, null, null, 8, false },
                    { 39, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03521_7efa50bb0f.jpg", false, null, null, 8, false },
                    { 40, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00146_7d022b2ddd.jpg", false, null, null, 9, true },
                    { 41, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00152_9dad73d9c3.jpg", false, null, null, 9, false },
                    { 42, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00153_bad1324204.jpg", false, null, null, 9, false },
                    { 43, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00154_baf22f1c94.jpg", false, null, null, 9, false },
                    { 44, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00006610_scanneuron_forte_4082_61df_large_203eef608c.jpg", false, null, null, 10, true },
                    { 45, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00006610_scanneuron_forte_7972_61df_large_bc5e17f862.jpg", false, null, null, 10, false },
                    { 46, null, null, null, null, "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00006610_scanneuron_forte_5617_61df_large_7218352645.jpg", false, null, null, 10, false }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ChildCategoryId", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, false, null, null, "Danh mục" },
                    { 2, 1, null, null, null, null, false, null, null, "Dạng bào chế" },
                    { 3, 1, null, null, null, null, false, null, null, "Quy cách" },
                    { 4, 1, null, null, null, null, false, null, null, "Thành Phần" },
                    { 5, 1, null, null, null, null, false, null, null, "Số đăng kí" },
                    { 6, 3, null, null, null, null, false, null, null, "Danh mục" },
                    { 7, 3, null, null, null, null, false, null, null, "Dạng bào chế" },
                    { 8, 3, null, null, null, null, false, null, null, "Quy cách" },
                    { 9, 3, null, null, null, null, false, null, null, "Thành phần" },
                    { 10, 3, null, null, null, null, false, null, null, "Số đăng kí" },
                    { 11, 4, null, null, null, null, false, null, null, "Danh mục" },
                    { 12, 4, null, null, null, null, false, null, null, "Dạng bào chế" },
                    { 13, 4, null, null, null, null, false, null, null, "Quy cách" },
                    { 14, 4, null, null, null, null, false, null, null, "Thành Phần" },
                    { 15, 4, null, null, null, null, false, null, null, "Số đăng kí" }
                });

            migrationBuilder.InsertData(
                table: "ProductMaterials",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Detail", "IsDeleted", "MaterialId", "ModificationBy", "ModificationDate", "ProductId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Thuốc kháng nấm", false, 1, null, null, 1 },
                    { 2, null, null, null, null, "Viên nang cứng", false, 2, null, null, 1 },
                    { 3, null, null, null, null, "Hộp 1 Vỉ x 1 Viên", false, 3, null, null, 1 },
                    { 4, null, null, null, null, "Fluconazol", false, 4, null, null, 1 },
                    { 5, null, null, null, null, "VD-35475-21", false, 5, null, null, 1 },
                    { 6, null, null, null, null, "Thuốc tăng cường tuần hoàn não", false, 6, null, null, 2 },
                    { 7, null, null, null, null, "Viên nén bao phim", false, 7, null, null, 2 },
                    { 8, null, null, null, null, "Hộp 3 Vỉ x 10 Viên", false, 8, null, null, 2 },
                    { 9, null, null, null, null, "Thục địa, Ích mẫu, Ngưu tất (Rễ), Đương quy, Xích thược, Xuyên khung", false, 9, null, null, 2 },
                    { 10, null, null, null, null, "VD-30094-18", false, 10, null, null, 2 },
                    { 11, null, null, null, null, "Thuốc tăng cường tuần hoàn não", false, 6, null, null, 3 },
                    { 12, null, null, null, null, "Viên nang mềm", false, 7, null, null, 3 },
                    { 13, null, null, null, null, "Hộp 6 Vỉ x 10 Viên", false, 8, null, null, 3 },
                    { 14, null, null, null, null, "Ginkgo biloba", false, 9, null, null, 3 },
                    { 15, null, null, null, null, "VD-27294-17", false, 10, null, null, 3 },
                    { 16, null, null, null, null, "Thuốc trị trĩ, suy giãn tĩnh mạch", false, 6, null, null, 4 },
                    { 17, null, null, null, null, "Viên nén bao phim", false, 7, null, null, 4 },
                    { 18, null, null, null, null, "Hộp 3 Vỉ x 10 Viên", false, 8, null, null, 4 },
                    { 19, null, null, null, null, "Diosmin, Hesperidin", false, 9, null, null, 4 },
                    { 20, null, null, null, null, "VD-30231-18", false, 10, null, null, 4 },
                    { 21, null, null, null, null, "Thuốc trị trĩ, suy giãn tĩnh mạch", false, 6, null, null, 5 },
                    { 22, null, null, null, null, "Viên nén bao phim", false, 7, null, null, 5 },
                    { 23, null, null, null, null, "Hộp 10 Vỉ x 10 Viên", false, 8, null, null, 5 },
                    { 24, null, null, null, null, "Diosmin, Hesperidin", false, 9, null, null, 5 },
                    { 25, null, null, null, null, "VD-30810-18", false, 10, null, null, 5 },
                    { 26, null, null, null, null, "Thuốc trị mỡ máu", false, 6, null, null, 6 },
                    { 27, null, null, null, null, "Viên nén bao phim", false, 7, null, null, 6 },
                    { 28, null, null, null, null, "Hộp 3 Vỉ x 10 Viên", false, 8, null, null, 6 },
                    { 29, null, null, null, null, "Rosuvastatin", false, 9, null, null, 6 },
                    { 30, null, null, null, null, "VN-22675-20", false, 10, null, null, 6 },
                    { 31, null, null, null, null, "Thuốc tim mạch huyết áp", false, 6, null, null, 7 },
                    { 32, null, null, null, null, "Viên nén bao phim", false, 7, null, null, 7 },
                    { 33, null, null, null, null, "Hộp 3 Vỉ x 10 Viên", false, 8, null, null, 7 },
                    { 34, null, null, null, null, "Valsartan", false, 9, null, null, 7 },
                    { 35, null, null, null, null, "VD-32469-19", false, 10, null, null, 7 },
                    { 36, null, null, null, null, "Thuốc trị mỡ máu", false, 6, null, null, 8 },
                    { 37, null, null, null, null, "Viên nén bao phim", false, 7, null, null, 8 },
                    { 38, null, null, null, null, "Hộp 3 Vỉ x 10 Viên", false, 8, null, null, 8 },
                    { 39, null, null, null, null, "Rosuvastatin", false, 9, null, null, 8 },
                    { 40, null, null, null, null, "VD-31018-18", false, 10, null, null, 8 },
                    { 41, null, null, null, null, "Thuốc thần kinh", false, 11, null, null, 9 },
                    { 42, null, null, null, null, "Viên nang mềm", false, 12, null, null, 9 },
                    { 43, null, null, null, null, "Hộp 6 Vỉ x 10 Viên", false, 13, null, null, 9 },
                    { 44, null, null, null, null, "Bạch quả, Đinh lăng", false, 14, null, null, 9 },
                    { 45, null, null, null, null, "VD-21622-14", false, 15, null, null, 9 },
                    { 46, null, null, null, null, "Thuốc thần kinh", false, 11, null, null, 10 },
                    { 47, null, null, null, null, "Viên nén bao phim", false, 12, null, null, 10 },
                    { 48, null, null, null, null, "Hộp 10 vỉ x 10 viên", false, 13, null, null, 10 },
                    { 49, null, null, null, null, "Vitamin B1, Vitamin B6, Vitamin B12", false, 14, null, null, 10 },
                    { 50, null, null, null, null, "VD-22677-15", false, 15, null, null, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressUsers_AddressToShipId",
                table: "AddressUsers",
                column: "AddressToShipId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressUsers_UserId",
                table: "AddressUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_ParentCategoryId",
                table: "ChildCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ProductId",
                table: "Feedbacks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ChildCategoryId",
                table: "Materials",
                column: "ChildCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressToShipId",
                table: "Orders",
                column: "AddressToShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipperId",
                table: "Orders",
                column: "ShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaterials_MaterialId",
                table: "ProductMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaterials_ProductId",
                table: "ProductMaterials",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportOfUsers_CommentId",
                table: "ReportOfUsers",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportOfUsers_ReportTypeId",
                table: "ReportOfUsers",
                column: "ReportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shippers_ShipCompanyId",
                table: "Shippers",
                column: "ShipCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherUsages_OrderId",
                table: "VoucherUsages",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherUsages_VoucherId",
                table: "VoucherUsages",
                column: "VoucherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressUsers");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductMaterials");

            migrationBuilder.DropTable(
                name: "ReportOfUsers");

            migrationBuilder.DropTable(
                name: "VoucherUsages");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ReportTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "ChildCategories");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AddressToShips");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "ParentCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ShipCompanies");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
