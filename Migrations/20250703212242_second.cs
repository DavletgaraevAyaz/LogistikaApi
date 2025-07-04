using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogistikaApi.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductMovements_MovementId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_MovementId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MovementId",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovementId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_MovementId",
                table: "Product",
                column: "MovementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductMovements_MovementId",
                table: "Product",
                column: "MovementId",
                principalTable: "ProductMovements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
