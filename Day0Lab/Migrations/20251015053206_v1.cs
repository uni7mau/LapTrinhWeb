using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Day0Lab.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KHACH_HANG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HoTenKhachHang = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHACH_HANG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOAI_SAN_PHAM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAI_SAN_PHAM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QUAN_TRI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUAN_TRI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaLoai = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAN_PHAM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SAN_PHAM_LOAI_SAN_PHAM_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LOAI_SAN_PHAM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HOA_DON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaKhaHang = table.Column<int>(type: "int", nullable: true),
                    NgayHoaDon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoTenKhachHang = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TongTriGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    QuanTriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOA_DON", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HOA_DON_KHACH_HANG_MaKhaHang",
                        column: x => x.MaKhaHang,
                        principalTable: "KHACH_HANG",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HOA_DON_QUAN_TRI_QuanTriId",
                        column: x => x.QuanTriId,
                        principalTable: "QUAN_TRI",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CT_HOA_DON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonID = table.Column<int>(type: "int", nullable: true),
                    SanPhamID = table.Column<int>(type: "int", nullable: true),
                    SoLuongMua = table.Column<int>(type: "int", nullable: true),
                    DonGiaMua = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_HOA_DON", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CT_HOA_DON_HOA_DON_HoaDonID",
                        column: x => x.HoaDonID,
                        principalTable: "HOA_DON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CT_HOA_DON_SAN_PHAM_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SAN_PHAM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "KHACH_HANG",
                columns: new[] { "ID", "DiaChi", "DienThoai", "Email", "HoTenKhachHang", "MaKhachHang", "MaKhau", "NgayDangKy", "TrangThai" },
                values: new object[] { 1, "Hà Nội", "0901234567", "nguyenvana@email.com", "Nguyễn Văn A", "KH001", null, new DateTime(2025, 10, 15, 12, 32, 6, 352, DateTimeKind.Local).AddTicks(5079), 1 });

            migrationBuilder.InsertData(
                table: "LOAI_SAN_PHAM",
                columns: new[] { "ID", "MaLoai", "TenLoai", "TrangThai" },
                values: new object[,]
                {
                    { 1, "LSP001", "Điện thoại", 1 },
                    { 2, "LSP002", "Laptop", 1 },
                    { 3, "LSP003", "Phụ kiện", 1 }
                });

            migrationBuilder.InsertData(
                table: "QUAN_TRI",
                columns: new[] { "ID", "MatKhau", "TaiKhoan", "TrangThai" },
                values: new object[] { 1, "123456", "admin", 1 });

            migrationBuilder.InsertData(
                table: "SAN_PHAM",
                columns: new[] { "ID", "DonGia", "HinhAnh", "MaLoai", "MaSanPham", "SoLuong", "TenSanPham", "TrangThai" },
                values: new object[,]
                {
                    { 1, 29990000m, null, 1, "SP001", 50, "iPhone 15 Pro", 1 },
                    { 2, 22990000m, null, 1, "SP002", 40, "Samsung Galaxy S24", 1 },
                    { 3, 45990000m, null, 2, "SP003", 20, "MacBook Pro M3", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOA_DON_HoaDonID",
                table: "CT_HOA_DON",
                column: "HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOA_DON_SanPhamID",
                table: "CT_HOA_DON",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_MaKhaHang",
                table: "HOA_DON",
                column: "MaKhaHang");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_QuanTriId",
                table: "HOA_DON",
                column: "QuanTriId");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MaLoai",
                table: "SAN_PHAM",
                column: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CT_HOA_DON");

            migrationBuilder.DropTable(
                name: "HOA_DON");

            migrationBuilder.DropTable(
                name: "SAN_PHAM");

            migrationBuilder.DropTable(
                name: "KHACH_HANG");

            migrationBuilder.DropTable(
                name: "QUAN_TRI");

            migrationBuilder.DropTable(
                name: "LOAI_SAN_PHAM");
        }
    }
}
