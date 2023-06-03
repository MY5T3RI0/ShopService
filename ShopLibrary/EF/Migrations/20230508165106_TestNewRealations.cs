#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLibrary.Models.EF.Migrations
{
    /// <inheritdoc />
    public partial class TestNewRealations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryInfo_Delivery_DeliveryId",
                table: "DeliveryInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Store_StoreId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryInfo",
                table: "DeliveryInfo");

            migrationBuilder.AddColumn<int>(
                name: "StoreProductsId",
                table: "PurchaseDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Purchase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "DeliveryInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DeliveryInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "DeliveryInfo",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryInfo",
                table: "DeliveryInfo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductsInStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInStore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsInStore_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInStore_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreProducts_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_StoreProductsId",
                table: "PurchaseDetails",
                column: "StoreProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryInfo_DeliveryId",
                table: "DeliveryInfo",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInStore_ProductId",
                table: "ProductsInStore",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInStore_StoreId",
                table: "ProductsInStore",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_PurchaseId",
                table: "StoreProducts",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_StoreId",
                table: "StoreProducts",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryInfo_Delivery_DeliveryId",
                table: "DeliveryInfo",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Store_StoreId",
                table: "Purchase",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_StoreProducts_StoreProductsId",
                table: "PurchaseDetails",
                column: "StoreProductsId",
                principalTable: "StoreProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryInfo_Delivery_DeliveryId",
                table: "DeliveryInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Store_StoreId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_StoreProducts_StoreProductsId",
                table: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "ProductsInStore");

            migrationBuilder.DropTable(
                name: "StoreProducts");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_StoreProductsId",
                table: "PurchaseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryInfo",
                table: "DeliveryInfo");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryInfo_DeliveryId",
                table: "DeliveryInfo");

            migrationBuilder.DropColumn(
                name: "StoreProductsId",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DeliveryInfo");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "DeliveryInfo");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "DeliveryInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryInfo",
                table: "DeliveryInfo",
                columns: new[] { "DeliveryId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryInfo_Delivery_DeliveryId",
                table: "DeliveryInfo",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Store_StoreId",
                table: "Purchase",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
