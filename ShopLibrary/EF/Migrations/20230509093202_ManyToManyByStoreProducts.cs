#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLibrary.Models.EF.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyByStoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Store_StoreId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_StoreId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Purchase");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_StoreId",
                table: "Purchase",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Store_StoreId",
                table: "Purchase",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id");
        }
    }
}
