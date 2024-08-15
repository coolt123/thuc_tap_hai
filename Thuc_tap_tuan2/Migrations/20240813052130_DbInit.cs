using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thuc_tap_tuan2.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doanhnghiep",
                columns: table => new
                {
                    IdDN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MST = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doanhnghiep", x => x.IdDN);
                });

            migrationBuilder.CreateTable(
                name: "sanpham",
                columns: table => new
                {
                    IdSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanpham", x => x.IdSP);
                });

            migrationBuilder.CreateTable(
                name: "doanhnghiepsanpham",
                columns: table => new
                {
                    IdSP = table.Column<int>(type: "int", nullable: false),
                    IdDN = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doanhnghiepsanpham", x => new { x.IdSP, x.IdDN });
                    table.ForeignKey(
                        name: "Fk_doanhnghiep",
                        column: x => x.IdDN,
                        principalTable: "doanhnghiep",
                        principalColumn: "IdDN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_sanpham",
                        column: x => x.IdSP,
                        principalTable: "sanpham",
                        principalColumn: "IdSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doanhnghiep_MST",
                table: "doanhnghiep",
                column: "MST",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_doanhnghiep_TenDN",
                table: "doanhnghiep",
                column: "TenDN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_doanhnghiepsanpham_IdDN",
                table: "doanhnghiepsanpham",
                column: "IdDN");

            migrationBuilder.CreateIndex(
                name: "IX_sanpham_MaSp",
                table: "sanpham",
                column: "MaSp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sanpham_TenSp",
                table: "sanpham",
                column: "TenSp",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doanhnghiepsanpham");

            migrationBuilder.DropTable(
                name: "doanhnghiep");

            migrationBuilder.DropTable(
                name: "sanpham");
        }
    }
}
