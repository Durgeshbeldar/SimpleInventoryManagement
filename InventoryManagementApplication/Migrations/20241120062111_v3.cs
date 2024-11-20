using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApplication.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedItems_PurchasedInvoices_PurchasedInvoiceInvoiceId",
                table: "PurchasedItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedItems_PurchasedInvoiceInvoiceId",
                table: "PurchasedItems");

            migrationBuilder.DropColumn(
                name: "PurchasedInvoiceInvoiceId",
                table: "PurchasedItems");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedItems_InvoiceId",
                table: "PurchasedItems",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedItems_PurchasedInvoices_InvoiceId",
                table: "PurchasedItems",
                column: "InvoiceId",
                principalTable: "PurchasedInvoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedItems_PurchasedInvoices_InvoiceId",
                table: "PurchasedItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedItems_InvoiceId",
                table: "PurchasedItems");

            migrationBuilder.AddColumn<int>(
                name: "PurchasedInvoiceInvoiceId",
                table: "PurchasedItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedItems_PurchasedInvoiceInvoiceId",
                table: "PurchasedItems",
                column: "PurchasedInvoiceInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedItems_PurchasedInvoices_PurchasedInvoiceInvoiceId",
                table: "PurchasedItems",
                column: "PurchasedInvoiceInvoiceId",
                principalTable: "PurchasedInvoices",
                principalColumn: "InvoiceId");
        }
    }
}
