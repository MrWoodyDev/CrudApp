using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApp.Persistence.Migrations
{
    public partial class EditNameReceiptTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckProduct");

            migrationBuilder.CreateTable(
                name: "ProductReceipt",
                columns: table => new
                {
                    ProductsId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiptsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReceipt", x => new { x.ProductsId, x.ReceiptsId });
                    table.ForeignKey(
                        name: "FK_ProductReceipt_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReceipt_Receipts_ReceiptsId",
                        column: x => x.ReceiptsId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReceipt_ReceiptsId",
                table: "ProductReceipt",
                column: "ReceiptsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReceipt");

            migrationBuilder.CreateTable(
                name: "CheckProduct",
                columns: table => new
                {
                    ChecksId = table.Column<long>(type: "bigint", nullable: false),
                    ProductsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckProduct", x => new { x.ChecksId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CheckProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckProduct_Receipts_ChecksId",
                        column: x => x.ChecksId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckProduct_ProductsId",
                table: "CheckProduct",
                column: "ProductsId");
        }
    }
}
