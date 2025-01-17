﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class DersOdevi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblogrenciler",
                table: "tblogrenciler");

            migrationBuilder.RenameTable(
                name: "tblogrenciler",
                newName: "tblOgrenciler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOgrenciler",
                table: "tblOgrenciler",
                column: "Ogrenciid");

            migrationBuilder.CreateTable(
                name: "tblDersler",
                columns: table => new
                {
                    Dersid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAd = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DersKodu = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Kredi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDersler", x => x.Dersid);
                });

            migrationBuilder.CreateTable(
                name: "tblOgrenciDersler",
                columns: table => new
                {
                    Ogrenciid = table.Column<int>(type: "int", nullable: false),
                    Dersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrenciDersler", x => new { x.Ogrenciid, x.Dersid });
                    table.ForeignKey(
                        name: "FK_tblOgrenciDersler_tblDersler_Dersid",
                        column: x => x.Dersid,
                        principalTable: "tblDersler",
                        principalColumn: "Dersid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOgrenciDersler_tblOgrenciler_Ogrenciid",
                        column: x => x.Ogrenciid,
                        principalTable: "tblOgrenciler",
                        principalColumn: "Ogrenciid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOgrenciDersler_Dersid",
                table: "tblOgrenciDersler",
                column: "Dersid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrenciDersler");

            migrationBuilder.DropTable(
                name: "tblDersler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOgrenciler",
                table: "tblOgrenciler");

            migrationBuilder.RenameTable(
                name: "tblOgrenciler",
                newName: "tblogrenciler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblogrenciler",
                table: "tblogrenciler",
                column: "Ogrenciid");
        }
    }
}
