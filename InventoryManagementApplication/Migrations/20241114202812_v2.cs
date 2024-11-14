using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApplication.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedItem_Products_ProductId",
                table: "PurchasedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedItem_PurchasedInvoices_PurchasedInvoiceInvoiceId",
                table: "PurchasedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItem_Products_ProductId",
                table: "SaleItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItem_SaleInvoices_SaleInvoiceInvoiceId",
                table: "SaleItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleItem",
                table: "SaleItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedItem",
                table: "PurchasedItem");

            migrationBuilder.RenameTable(
                name: "SaleItem",
                newName: "SaleItems");

            migrationBuilder.RenameTable(
                name: "PurchasedItem",
                newName: "PurchasedItems");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItem_SaleInvoiceInvoiceId",
                table: "SaleItems",
                newName: "IX_SaleItems_SaleInvoiceInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItem_ProductId",
                table: "SaleItems",
                newName: "IX_SaleItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedItem_PurchasedInvoiceInvoiceId",
                table: "PurchasedItems",
                newName: "IX_PurchasedItems_PurchasedInvoiceInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedItem_ProductId",
                table: "PurchasedItems",
                newName: "IX_PurchasedItems_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "SaleItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "PurchasedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleItems",
                table: "SaleItems",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedItems",
                table: "PurchasedItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedItems_Products_ProductId",
                table: "PurchasedItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedItems_PurchasedInvoices_PurchasedInvoiceInvoiceId",
                table: "PurchasedItems",
                column: "PurchasedInvoiceInvoiceId",
                principalTable: "PurchasedInvoices",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Products_ProductId",
                table: "SaleItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_SaleInvoices_SaleInvoiceInvoiceId",
                table: "SaleItems",
                column: "SaleInvoiceInvoiceId",
                principalTable: "SaleInvoices",
                principalColumn: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedItems_Products_ProductId",
                table: "PurchasedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedItems_PurchasedInvoices_PurchasedInvoiceInvoiceId",
                table: "PurchasedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Products_ProductId",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_SaleInvoices_SaleInvoiceInvoiceId",
                table: "SaleItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleItems",
                table: "SaleItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedItems",
                table: "PurchasedItems");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "SaleItems");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "PurchasedItems");

            migrationBuilder.RenameTable(
                name: "SaleItems",
                newName: "SaleItem");

            migrationBuilder.RenameTable(
                name: "PurchasedItems",
                newName: "PurchasedItem");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_SaleInvoiceInvoiceId",
                table: "SaleItem",
                newName: "IX_SaleItem_SaleInvoiceInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_ProductId",
                table: "SaleItem",
                newName: "IX_SaleItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedItems_PurchasedInvoiceInvoiceId",
                table: "PurchasedItem",
                newName: "IX_PurchasedItem_PurchasedInvoiceInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedItems_ProductId",
                table: "PurchasedItem",
                newName: "IX_PurchasedItem_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleItem",
                table: "SaleItem",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedItem",
                table: "PurchasedItem",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedItem_Products_ProductId",
                table: "PurchasedItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedItem_PurchasedInvoices_PurchasedInvoiceInvoiceId",
                table: "PurchasedItem",
                column: "PurchasedInvoiceInvoiceId",
                principalTable: "PurchasedInvoices",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItem_Products_ProductId",
                table: "SaleItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItem_SaleInvoices_SaleInvoiceInvoiceId",
                table: "SaleItem",
                column: "SaleInvoiceInvoiceId",
                principalTable: "SaleInvoices",
                principalColumn: "InvoiceId");
        }
    }
}
