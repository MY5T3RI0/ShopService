#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLibrary.Models.EF.Migrations
{
    /// <inheritdoc />
    public partial class fixedSomeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryInfo_Delivery_DeliveryId",
                table: "DeliveryInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInStore_Store_StoreId",
                table: "ProductsInStore");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_StoreProducts_StoreProductsId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProducts_Purchase_PurchaseId",
                table: "StoreProducts");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "StoreProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StoreProductsId",
                table: "PurchaseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "ProductsInStore",
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

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryInfo_Delivery_DeliveryId",
                table: "DeliveryInfo",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInStore_Store_StoreId",
                table: "ProductsInStore",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_StoreProducts_StoreProductsId",
                table: "PurchaseDetails",
                column: "StoreProductsId",
                principalTable: "StoreProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProducts_Purchase_PurchaseId",
                table: "StoreProducts",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryInfo_Delivery_DeliveryId",
                table: "DeliveryInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInStore_Store_StoreId",
                table: "ProductsInStore");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_StoreProducts_StoreProductsId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProducts_Purchase_PurchaseId",
                table: "StoreProducts");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "StoreProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StoreProductsId",
                table: "PurchaseDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "ProductsInStore",
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

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryInfo_Delivery_DeliveryId",
                table: "DeliveryInfo",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInStore_Store_StoreId",
                table: "ProductsInStore",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_StoreProducts_StoreProductsId",
                table: "PurchaseDetails",
                column: "StoreProductsId",
                principalTable: "StoreProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProducts_Purchase_PurchaseId",
                table: "StoreProducts",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id");
        }
    }
}
