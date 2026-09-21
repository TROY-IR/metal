using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metal.persistance.Migrations
{
    /// <inheritdoc />
    public partial class orderu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SendType",
                table: "RequestPays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "cimgdetail",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cimgsrc",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendType",
                table: "RequestPays");

            migrationBuilder.DropColumn(
                name: "cimgdetail",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "cimgsrc",
                table: "orders");
        }
    }
}
