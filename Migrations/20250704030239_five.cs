using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogistikaApi.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_ReceiverId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_ReceiverId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Message",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverId",
                table: "Message",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_ReceiverId",
                table: "Message",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
