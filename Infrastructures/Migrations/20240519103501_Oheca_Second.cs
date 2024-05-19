using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Oheca_Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConfirmationToken",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Vouchers",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Vouchers",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Users",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Users",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Users",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Products",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Products",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "Products",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Posts",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "Posts",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Images",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Images",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Images",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Feedbacks",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Discounts",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Comments",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "Comments",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CommentBy",
                table: "Comments",
                newName: "DeleteBy");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "VoucherUsages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "VoucherUsages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "VoucherUsages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "VoucherUsages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VoucherUsages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "VoucherUsages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "VoucherUsages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Vouchers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Vouchers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Vouchers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "Vouchers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Shippers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Shippers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Shippers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Shippers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Shippers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "Shippers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Shippers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ShipCompanies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ShipCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "ShipCompanies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ShipCompanies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShipCompanies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "ShipCompanies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ShipCompanies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ReportTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ReportTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "ReportTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ReportTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReportTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "ReportTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ReportTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ReportOfUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ReportOfUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "ReportOfUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ReportOfUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReportOfUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "ReportOfUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ReportOfUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ProductMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductMaterials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "ProductMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductMaterials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductMaterials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "ProductMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductMaterials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Posts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Payments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Payments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ParentCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ParentCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "ParentCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ParentCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ParentCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "ParentCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ParentCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Materials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Materials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Materials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Feedbacks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Feedbacks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Discounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Discounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Discounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ChildCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ChildCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "ChildCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ChildCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ChildCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "ChildCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ChildCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "AddressUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AddressUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "AddressUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "AddressUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AddressUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "AddressUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "AddressUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "AddressToShips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AddressToShips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "AddressToShips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "AddressToShips",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AddressToShips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModificationBy",
                table: "AddressToShips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "AddressToShips",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VoucherUsages");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "VoucherUsages");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "VoucherUsages");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "VoucherUsages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VoucherUsages");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "VoucherUsages");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "VoucherUsages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShipCompanies");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ShipCompanies");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ShipCompanies");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ShipCompanies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShipCompanies");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "ShipCompanies");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ShipCompanies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ReportTypes");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ReportTypes");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ReportTypes");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ReportTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReportTypes");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "ReportTypes");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ReportTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ReportOfUsers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ReportOfUsers");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ReportOfUsers");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ReportOfUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReportOfUsers");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "ReportOfUsers");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ReportOfUsers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductMaterials");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductMaterials");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ProductMaterials");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductMaterials");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductMaterials");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "ProductMaterials");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductMaterials");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AddressUsers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AddressUsers");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "AddressUsers");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "AddressUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AddressUsers");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "AddressUsers");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "AddressUsers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AddressToShips");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AddressToShips");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "AddressToShips");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "AddressToShips");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AddressToShips");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "AddressToShips");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "AddressToShips");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Vouchers",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Vouchers",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Users",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Users",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Users",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Products",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Products",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Products",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Posts",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Posts",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Images",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Images",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Images",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Feedbacks",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Discounts",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Comments",
                newName: "CommentDate");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Comments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Comments",
                newName: "CommentBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationToken",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
