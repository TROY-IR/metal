using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metal.persistance.Migrations
{
    /// <inheritdoc />
    public partial class Uimedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MediaImages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mediaid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_MediaImages_Medias_Mediaid",
                        column: x => x.Mediaid,
                        principalTable: "Medias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaProducts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mediaid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_MediaProducts_Medias_Mediaid",
                        column: x => x.Mediaid,
                        principalTable: "Medias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaTexts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mediaid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTexts", x => x.id);
                    table.ForeignKey(
                        name: "FK_MediaTexts_Medias_Mediaid",
                        column: x => x.Mediaid,
                        principalTable: "Medias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaImages_Mediaid",
                table: "MediaImages",
                column: "Mediaid");

            migrationBuilder.CreateIndex(
                name: "IX_MediaProducts_Mediaid",
                table: "MediaProducts",
                column: "Mediaid");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTexts_Mediaid",
                table: "MediaTexts",
                column: "Mediaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaImages");

            migrationBuilder.DropTable(
                name: "MediaProducts");

            migrationBuilder.DropTable(
                name: "MediaTexts");

            migrationBuilder.DropTable(
                name: "Medias");
        }
    }
}
