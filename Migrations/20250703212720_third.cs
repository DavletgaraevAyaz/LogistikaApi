using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogistikaApi.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMovements_MaintenanceMovementType_MovementTypeId",
                table: "ProductMovements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceMovementType",
                table: "MaintenanceMovementType");

            migrationBuilder.RenameTable(
                name: "MaintenanceMovementType",
                newName: "MovementType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovementType",
                table: "MovementType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMovements_MovementType_MovementTypeId",
                table: "ProductMovements",
                column: "MovementTypeId",
                principalTable: "MovementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMovements_MovementType_MovementTypeId",
                table: "ProductMovements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovementType",
                table: "MovementType");

            migrationBuilder.RenameTable(
                name: "MovementType",
                newName: "MaintenanceMovementType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceMovementType",
                table: "MaintenanceMovementType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMovements_MaintenanceMovementType_MovementTypeId",
                table: "ProductMovements",
                column: "MovementTypeId",
                principalTable: "MaintenanceMovementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
