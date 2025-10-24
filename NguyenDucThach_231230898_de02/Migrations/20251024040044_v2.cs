using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenDucThach_231230898_de02.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguyenDucThachCatalog",
                columns: table => new
                {
                    hvtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hvtCateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hvtCatePrice = table.Column<double>(type: "float", nullable: false),
                    hvtCateQty = table.Column<int>(type: "int", nullable: false),
                    hvtPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hvtCateActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguyenDucThachCatalog", x => x.hvtId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguyenDucThachCatalog");
        }
    }
}
