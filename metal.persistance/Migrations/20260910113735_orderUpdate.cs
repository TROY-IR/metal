using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metal.persistance.Migrations
{
    /// <inheritdoc />
    public partial class orderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ordimgdetail",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ordimgsrc",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "postcode",
                table: "orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ordimgdetail",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ordimgsrc",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "postcode",
                table: "orders");
        }
    }
}
