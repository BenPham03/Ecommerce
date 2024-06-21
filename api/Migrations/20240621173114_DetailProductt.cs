using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DetailProductt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "274cf171-3db9-4f15-9c9b-a54147027b56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8392f472-4684-46d8-9558-884c1c1a583c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60ba5c40-7c16-4797-a342-5560096f582d", null, "User", "User" },
                    { "79997d13-57e8-4679-a0d0-00f9b21b7dac", null, "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_DetailProductId",
                table: "Product",
                column: "DetailProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_DetailProduct_DetailProductId",
                table: "Product",
                column: "DetailProductId",
                principalTable: "DetailProduct",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_DetailProduct_DetailProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_DetailProductId",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60ba5c40-7c16-4797-a342-5560096f582d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79997d13-57e8-4679-a0d0-00f9b21b7dac");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "274cf171-3db9-4f15-9c9b-a54147027b56", null, "User", "User" },
                    { "8392f472-4684-46d8-9558-884c1c1a583c", null, "Admin", "Admin" }
                });
        }
    }
}
