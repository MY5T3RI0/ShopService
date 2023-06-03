using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLibrary.Models.EF.Migrations
{
    /// <inheritdoc />
    public partial class fixedDeliveryInfoRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryInfo",
                table: "DeliveryInfo");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryInfo_DeliveryId",
                table: "DeliveryInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryInfo",
                table: "DeliveryInfo",
                columns: new[] { "DeliveryId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryInfo_ProductId",
                table: "DeliveryInfo",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryInfo",
                table: "DeliveryInfo");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryInfo_ProductId",
                table: "DeliveryInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryInfo",
                table: "DeliveryInfo",
                columns: new[] { "ProductId", "DeliveryId" });

            migrationBuilder.CreateTable(
                name: "DeliveryProduct",
                columns: table => new
                {
                    DeliveriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryProduct", x => new { x.DeliveriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_DeliveryProduct_Delivery_DeliveriesId",
                        column: x => x.DeliveriesId,
                        principalTable: "Delivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryProduct_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryInfo_DeliveryId",
                table: "DeliveryInfo",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProduct_ProductsId",
                table: "DeliveryProduct",
                column: "ProductsId");
        }
    }
}
