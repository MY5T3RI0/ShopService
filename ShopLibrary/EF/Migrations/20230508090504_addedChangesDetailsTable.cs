#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLibrary.Models.EF.Migrations
{
    /// <inheritdoc />
    public partial class addedChangesDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceChange_Product_ProductId",
                table: "PriceChange");

            migrationBuilder.DropIndex(
                name: "IX_PriceChange_ProductId",
                table: "PriceChange");

            migrationBuilder.DropColumn(
                name: "NewPrice",
                table: "PriceChange");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PriceChange");

            migrationBuilder.CreateTable(
                name: "ChangeDetails",
                columns: table => new
                {
                    PriceChangesId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeDetails", x => new { x.PriceChangesId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ChangeDetails_PriceChange_PriceChangesId",
                        column: x => x.PriceChangesId,
                        principalTable: "PriceChange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeDetails_ProductId",
                table: "ChangeDetails",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "NewPrice",
                table: "PriceChange",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PriceChange",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PriceChange_ProductId",
                table: "PriceChange",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceChange_Product_ProductId",
                table: "PriceChange",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
