using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTTrenlop17_10.Migrations
{
    /// <inheritdoc />
    public partial class nw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TVCLoaiSanPham",
                columns: table => new
                {
                    PVCId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TVCMaLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TVCTenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TVCTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVCLoaiSanPham", x => x.PVCId);
                });

            migrationBuilder.CreateTable(
                name: "TVCSanPham",
                columns: table => new
                {
                    TVCId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TVCMasanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TVCTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TVCHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TVCSoLuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TVCDonGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TVCLoaiSanPhamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVCSanPham", x => x.TVCId);
                    table.ForeignKey(
                        name: "FK_TVCSanPham_TVCLoaiSanPham_TVCLoaiSanPhamId",
                        column: x => x.TVCLoaiSanPhamId,
                        principalTable: "TVCLoaiSanPham",
                        principalColumn: "PVCId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVCLoaiSanPham_TVCMaLoai",
                table: "TVCLoaiSanPham",
                column: "TVCMaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_TVCSanPham_TVCLoaiSanPhamId",
                table: "TVCSanPham",
                column: "TVCLoaiSanPhamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TVCSanPham");

            migrationBuilder.DropTable(
                name: "TVCLoaiSanPham");
        }
    }
}
