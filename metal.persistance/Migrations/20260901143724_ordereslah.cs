using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metal.persistance.Migrations
{
    /// <inheritdoc />
    public partial class ordereslah : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_RequestPays_RequestPayId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_Users_UserId",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_RequestPays_RequestPayId",
                table: "orders",
                column: "RequestPayId",
                principalTable: "RequestPays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Users_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_RequestPays_RequestPayId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_Users_UserId",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_RequestPays_RequestPayId",
                table: "orders",
                column: "RequestPayId",
                principalTable: "RequestPays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Users_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
