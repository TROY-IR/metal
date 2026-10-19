using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace metal.persistance.Migrations
{
    /// <inheritdoc />
    public partial class dorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Userinroles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Userinroles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Userinroles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Userinroles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "orderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "txchra",
                table: "orderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Defavs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Defavs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Defavs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Defavs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dCartItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txchra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tozih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imsrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dCartItems_carts_CartId",
                        column: x => x.CartId,
                        principalTable: "carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dOrderDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    txchra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tozih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imsrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dOrderDetails_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cunt = table.Column<int>(type: "int", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_likes_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    msize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "texras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mtexra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_texras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "likechildren",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    likeid = table.Column<long>(type: "bigint", nullable: false),
                    productid = table.Column<long>(type: "bigint", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likechildren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_likechildren_Products_productid",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_likechildren_likes_likeid",
                        column: x => x.likeid,
                        principalTable: "likes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dCartItems_CartId",
                table: "dCartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_dOrderDetails_OrderId",
                table: "dOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_likechildren_likeid",
                table: "likechildren",
                column: "likeid");

            migrationBuilder.CreateIndex(
                name: "IX_likechildren_productid",
                table: "likechildren",
                column: "productid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dCartItems");

            migrationBuilder.DropTable(
                name: "dOrderDetails");

            migrationBuilder.DropTable(
                name: "likechildren");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "texras");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Userinroles");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Userinroles");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Userinroles");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Userinroles");

            migrationBuilder.DropColumn(
                name: "size",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "txchra",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Defavs");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Defavs");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Defavs");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Defavs");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Admin" },
                    { 2L, "Operator" },
                    { 3L, "Customer" }
                });
        }
    }
}
